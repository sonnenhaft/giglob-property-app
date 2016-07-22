using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRS;
using Domain.Entities.Implementation.City;
using Domain.Entities.Implementation.City.Queries;
using Domain.Entities.Implementation.File.Queries;
using Domain.Entities.Implementation.PropertyOffer.Enums;
using Domain.Extensions;
using FluentValidation;
using FluentValidation.Resources;
using FluentValidation.Results;
using FluentValidation.Validators;
using SimpleInjector;

namespace Client.Api.v1.Models.Models.PropertyOffer.Validators
{
    public class PropertyOfferCreateRequestModelValidator : AbstractValidator<PropertyOfferCreateRequestModel>
    {
        public PropertyOfferCreateRequestModelValidator(IServiceProvider serviceProvider)
        {
            RuleFor(model => model.StreetName)
                .NotEmpty()
                .WithMessage("Введите улицу");

            RuleFor(model => model.HouseNumber)
                .NotEmpty()
                .WithMessage("Введите номер дома");

            RuleFor(model => model.ApartmentNumber)
                .NotEmpty()
                .WithMessage("Введите номер квартиры");

            RuleFor(model => model.Level)
                .NotEqual(0)
                .WithMessage("Введите этаж")
                .Must(level => level > 0 && level < 1000)
                .WithMessage("Некорректный этаж");

            RuleFor(model => model.AreaSize)
                .NotEqual(0)
                .WithMessage("Введите площадь")
                .Must(areaSize => areaSize > 0 && areaSize < 10000)
                .WithMessage("Некорректная площадь");

            RuleFor(model => model.RoomCount)
                .NotEqual(0)
                .WithMessage("Введите количество комнат")
                .Must(roomCount => roomCount > 0 && roomCount < 100)
                .WithMessage("Некорректное количество комнат");

            RuleFor(model => model.Type)
                .Must(type => type.IsEnumSingleValue())
                .WithMessage("Некорректный тип");

            RuleFor(model => model.BuildingCategory)
                .Must(buildingCategory => buildingCategory.IsEnumSingleValue())
                .WithMessage("Некорректная категория строения");

            RuleFor(model => model.Cost)
                .Must(cost => cost > 0 && cost < 1000000000000)
                .WithMessage("Некорректная стоимость");

            RuleFor(model => model.Comment)
                .NotEmpty()
                .WithMessage("Введите комментарий");

            RuleFor(model => model.Lat)
                .Must(latitude => latitude >= -90 && latitude <= 90)
                .WithMessage("Некорректная широта");

            RuleFor(model => model.Lon)
                .Must(longitude => longitude >= -180 && longitude <= 180)
                .WithMessage("Некорректная долгота");


            Custom(model => ValidateCityIdDistrictIdAndMetroStations(
                (IQueryHandler<City_IsExistsQuery, bool>)serviceProvider.GetService(typeof(IQueryHandler<City_IsExistsQuery, bool>)),
                (IQueryHandler<City_GetAllDistrictsQuery, IEnumerable<District>>)serviceProvider.GetService(typeof(IQueryHandler<City_GetAllDistrictsQuery, IEnumerable<District>>)),
                (IQueryHandler<City_ContainsMetroBranchStationsWithGivenIdsQuery, bool>)serviceProvider.GetService(typeof(IQueryHandler<City_ContainsMetroBranchStationsWithGivenIdsQuery, bool>)),
                model.CityId,
                model.DistrictId,
                model.NearMetroBranchStationIds
                ));

            Custom(model => ValidatePhotoes(
                (IQueryHandler<File_HasFilesWithGivenIdsAndExtensionsQuery, bool>)serviceProvider.GetService(typeof(IQueryHandler<File_HasFilesWithGivenIdsAndExtensionsQuery, bool>)),
                model.Photoes
                ));

            Custom(model => ValidateDocuments(
                (IQueryHandler<File_HasFilesWithGivenIdsAndExtensionsQuery, bool>)serviceProvider.GetService(typeof(IQueryHandler<File_HasFilesWithGivenIdsAndExtensionsQuery, bool>)),
                model.Documents
                ));

            #region PropertyOfferExchangeDetails        

            //-----------------------------------------------------------------------

            When(x => x.OfferType == OfferType.Exchange && x.ExchangeDetails == null, () =>
            {
                RuleFor(model => model.ExchangeDetails).NotNull()
                  .WithMessage("Требуется заполнить форму \"Куда хочу переехать\"");
            });

            When(x => x.OfferType == OfferType.Exchange && x.ExchangeDetails != null, () =>
              {
                  RuleFor(model => model.ExchangeDetails.MinCost)
                    .Must(cost => cost > 0 && cost < 1000000000000)
                    .WithMessage("Некорректная стоимость");


                  RuleFor(model => model.ExchangeDetails.MaxCost)
                    .Must(cost => cost > 0 && cost < 1000000000000)
                    .WithMessage("Некорректная стоимость");


                  RuleFor(model => model.ExchangeDetails)
                      .Must(x => x.MinCost < x.MaxCost)
                      .WithMessage("Стоимость \"От\" должна быть меньше стоимости \"До\"");

                  Custom(model => ValidateCityIdDistrictId(
                     (IQueryHandler<City_IsExistsQuery, bool>)serviceProvider.GetService(typeof(IQueryHandler<City_IsExistsQuery, bool>)),
                     (IQueryHandler<City_GetAllDistrictsQuery, IEnumerable<District>>)serviceProvider.GetService(typeof(IQueryHandler<City_GetAllDistrictsQuery, IEnumerable<District>>)),
                     model.CityId,
                     model.DistrictId));
              });

            //-----------------------------------------------------------------------

            #endregion PropertyOfferExchangeDetails
        }

        public ValidationFailure ValidateCityIdDistrictIdAndMetroStations(
            IQueryHandler<City_IsExistsQuery, bool> cityIsExistsQueryHandler,
            IQueryHandler<City_GetAllDistrictsQuery, IEnumerable<District>> cityGetAllDistrictsQuery,
            IQueryHandler<City_ContainsMetroBranchStationsWithGivenIdsQuery, bool> cityContainsMetroBranchStationsWithGivenIdsQueryHandler,
            long cityId,
            long? districtId,
            IEnumerable<long> nearMetroBranchStationIds)
        {
            if (!cityIsExistsQueryHandler.Handle(new City_IsExistsQuery(cityId)))
            {
                return new ValidationFailure("CityId", "Некорректный город");
            }

            var cityDistricts = cityGetAllDistrictsQuery.Handle(new City_GetAllDistrictsQuery(cityId));
            var cityHasDistricts = cityDistricts.Any();

            if (cityHasDistricts && !districtId.HasValue)
            {
                return new ValidationFailure("DistrictId", "Укажите район");
            }

            if (!cityHasDistricts && districtId.HasValue)
            {
                return new ValidationFailure("DistrictId", "Некорректный район");
            }

            if (districtId.HasValue && !cityDistricts.Select(x => x.Id).Contains(districtId.Value))
            {
                return new ValidationFailure("DistrictId", "Некорректный район");
            }

            if (!cityContainsMetroBranchStationsWithGivenIdsQueryHandler.Handle(new City_ContainsMetroBranchStationsWithGivenIdsQuery(cityId, nearMetroBranchStationIds)))
            {
                return new ValidationFailure("NearMetroBranchStationIds", "Некорректные станции метро");
            }

            return null;
        }

        public ValidationFailure ValidateCityIdDistrictId(
          IQueryHandler<City_IsExistsQuery, bool> cityIsExistsQueryHandler,
          IQueryHandler<City_GetAllDistrictsQuery, IEnumerable<District>> cityGetAllDistrictsQuery,
          long cityId,
          long? districtId)
        {
            if (!cityIsExistsQueryHandler.Handle(new City_IsExistsQuery(cityId)))
            {
                return new ValidationFailure("CityId", "Некорректный город");
            }

            var cityDistricts = cityGetAllDistrictsQuery.Handle(new City_GetAllDistrictsQuery(cityId));
            var cityHasDistricts = cityDistricts.Any();

            if (cityHasDistricts && !districtId.HasValue)
            {
                return new ValidationFailure("DistrictId", "Укажите район");
            }

            if (!cityHasDistricts && districtId.HasValue)
            {
                return new ValidationFailure("DistrictId", "Некорректный район");
            }

            if (districtId.HasValue && !cityDistricts.Select(x => x.Id).Contains(districtId.Value))
            {
                return new ValidationFailure("DistrictId", "Некорректный район");
            }

            return null;
        }

        public ValidationFailure ValidatePhotoes(IQueryHandler<File_HasFilesWithGivenIdsAndExtensionsQuery, bool> fileHasFilesWithGivenIdsQuery, IEnumerable<PropertyOfferCreatePhotoRequestModel> photoes)
        {
            if (photoes != null && photoes.Any())
            {
                if (photoes.Count() > 20)
                {
                    return new ValidationFailure("Photoes", "Максимальное количество фотографий - 20");
                }

                if (!fileHasFilesWithGivenIdsQuery.Handle(new File_HasFilesWithGivenIdsAndExtensionsQuery(photoes.Select(photo => photo.Id), new[] { "jpg", "png" })))
                {
                    return new ValidationFailure("Photoes", "Некорректные идентификаторы фотографий");
                }

                if (photoes.Count(photo => photo.IsCover) != 1)
                {
                    return new ValidationFailure("Photoes", "Укажите одну фотографию в качестве обложки");
                }
            }

            return null;
        }

        public ValidationFailure ValidateDocuments(IQueryHandler<File_HasFilesWithGivenIdsAndExtensionsQuery, bool> fileHasFilesWithGivenIdsQuery, IEnumerable<Guid> documentIds)
        {
            if (documentIds != null && documentIds.Any())
            {
                if (documentIds.Count() > 20)
                {
                    return new ValidationFailure("Documents", "Максимальное количество документов - 20");
                }

                if (!fileHasFilesWithGivenIdsQuery.Handle(new File_HasFilesWithGivenIdsAndExtensionsQuery(documentIds, new[] { "doc", "docx", "pages", "pdf", "odf" })))
                {
                    return new ValidationFailure("Documents", "Некорректные идентификаторы документов");
                }
            }

            return null;
        }
    }
}
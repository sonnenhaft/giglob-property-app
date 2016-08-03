using System;

namespace Domain.Entities.Implementation.PropertyOffer.Dtos
{
    public class PropertyOfferCreatePhotoContext
    {
        /// <summary>
        ///     Идентификатор файла
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Является ли фотография обложкой
        /// </summary>
        public bool IsCover { get; set; }
    }
}
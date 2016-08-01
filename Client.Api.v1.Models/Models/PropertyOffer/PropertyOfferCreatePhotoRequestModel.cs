using System;

namespace Client.Api.v1.Models.Models.PropertyOffer
{
    public class PropertyOfferCreatePhotoRequestModel
    {
        /// <summary>
        /// Идентификатор файла
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Является ли фотография обложкой
        /// </summary>
        public bool IsCover { get; set; }
    }
}
using System.Collections.Generic;

namespace Domain.Entities.Implementation.Property
{
    public class ExternalPropertyOfferData
    {
        public long PropertyOfferId { get; set; }

        public long ExternalUserId { get; set; }

        public string CityName { get; set; }

        public string DistrictName { get; set; }

        public ICollection<ExternalPropertyOfferImage> Images { get; set; }
    }
}
namespace Domain.Entities.Implementation.PropertyOffer
{
    public class ExternalPropertyOfferImage
    {
        public long Id { get; set; }

        public long PropertyOfferId { get; set; }

        public string Url { get; set; } 
    }
}
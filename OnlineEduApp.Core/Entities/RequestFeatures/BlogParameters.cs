namespace OnlineEduApp.Core.Entities.RequestFeatures
{
    public class BlogParameters : RequestParameters
    {
        public uint MinPrice { get; set; }
        public uint MaxPrice { get; set; } = 1000;
        public bool ValidPriceRange => MaxPrice > MinPrice;

    }
}

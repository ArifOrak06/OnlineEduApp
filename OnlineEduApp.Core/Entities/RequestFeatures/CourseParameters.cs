namespace OnlineEduApp.Core.Entities.RequestFeatures
{
    public class CourseParameters : RequestParameters
    {
        public uint MinPrice { get; set; }
        public uint MaxPrice { get; set; } = 1000;
        public bool ValidPriceRange => MinPrice >= 0 && MaxPrice >= 0 && MaxPrice > MinPrice;
    }
}

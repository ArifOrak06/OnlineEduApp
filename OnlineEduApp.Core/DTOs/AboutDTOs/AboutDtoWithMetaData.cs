using OnlineEduApp.Core.Entities.RequestFeatures;

namespace OnlineEduApp.Core.DTOs.AboutDTOs
{
    public class AboutDtoWithMetaData
    {
        public List<AboutDto> Abouts { get; set; }
        public MetaData MetaData { get; set; }
    }
}

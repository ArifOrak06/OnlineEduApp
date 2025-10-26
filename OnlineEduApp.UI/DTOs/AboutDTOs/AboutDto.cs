using OnlineEduApp.UI.Models;

namespace OnlineEduApp.UI.DTOs.AboutDTOs
{
    public class AboutDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ImageUrlTwo { get; set; }
        public string ItemOne { get; set; }
        public string ItemTwo { get; set; }
        public string ItemThree { get; set; }
        public string ItemFour { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        //public MetaData MetaData { get; set; }
    }
}

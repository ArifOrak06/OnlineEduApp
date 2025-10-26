using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.Core.UI.AboutDTOs
{
    public abstract class AboutDtoForManipulation
    {
        [Required(ErrorMessage = "Hakkımızda açıklama alanı boş geçilemez")]
        [Display(Name = "Hakkımında Açıklama")]
        [MinLength(100,ErrorMessage = "Açıklama alanı en az 100 karakter olmalıdır")]

        public string Description { get; set; } = null!;
        [Required(ErrorMessage ="Resim url 1 alanı boş geçilemez")]
        [Display(Name ="Resim Url 1")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Resim url 2 alanı boş geçilemez")]
        [Display(Name = "Resim Url 2")]
        public string ImageUrlTwo { get; set; }
        [Required(ErrorMessage = "Hakkımızda birinci kısım alanı boş geçilemez")]
        [Display(Name = "Hakkımızda Birinci Kısım")]
        public string ItemOne { get; set; }
        [Required(ErrorMessage = "Hakkımızda ikinci kısım alanı boş geçilemez")]
        [Display(Name = "Hakkımızda İkinci Kısım")]
        public string ItemTwo { get; set; }
        [Required(ErrorMessage = "Hakkımızda üçüncü kısım alanı boş geçilemez")]
        [Display(Name = "Hakkımızda Üçüncü Kısım")]
        public string ItemThree { get; set; }
        [Required(ErrorMessage = "Hakkımızda dördüncü kısım alanı boş geçilemez")]
        [Display(Name = "Hakkımızda Dördüncü Kısım")]
        public string ItemFour { get; set; }


    }
}

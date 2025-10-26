using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.UI.DTOs.ContactDTOs
{
    public class ContactDtoForUpdate : ContactDtoForManipulation
    {
        [Required(ErrorMessage = "Id zorunlu bir alandır.")]
        public int Id { get; set; }

        public bool IsActive { get; set; }
    }
}

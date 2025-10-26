using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.UI.DTOs.MessageDTOs
{
    public sealed class MessageDtoForUpdate : MessageDtoForManipulation
    {
        [Required(ErrorMessage = "Id zorunlu bir alandır.")]
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}

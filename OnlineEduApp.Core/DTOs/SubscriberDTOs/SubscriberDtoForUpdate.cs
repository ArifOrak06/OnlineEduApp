using System.ComponentModel.DataAnnotations;

namespace OnlineEduApp.Core.DTOs.SubscriberDTOs
{
    public sealed class SubscriberDtoForUpdate : SubscriberDtoForManipulation
    {
        [Required(ErrorMessage = "Id zorunlu bir alandır.")]
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}

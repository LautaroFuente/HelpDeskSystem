using System.ComponentModel.DataAnnotations;

namespace MesaDeAyuda.API.DTOs
{
    public class CreateTicketDTO
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, ErrorMessage = "Title cannot exceed 50 characters")]
        public string title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters")]
        public string description { get; set; }
    }
}

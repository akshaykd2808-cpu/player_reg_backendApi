using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace playerregproject.Models

{
    public class Form
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FormName { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Amount { get; set; }
        

        public string? ImageUrl { get; set; }  // store image path

        [NotMapped]
        public IFormFile Image { get; set; }

        public bool isActive { get; set; } 

        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }

}

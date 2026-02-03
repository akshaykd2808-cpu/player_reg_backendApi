using System.ComponentModel.DataAnnotations;

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
        [Required]

        public int isActive { get; set; } = 1;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }

}

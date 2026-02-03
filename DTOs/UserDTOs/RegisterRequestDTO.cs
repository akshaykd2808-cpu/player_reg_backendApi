using System.ComponentModel.DataAnnotations;

namespace playerregproject.DTOs.UserDTOs
{
    public class RegisterRequestDTO
    {

        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

    }
}

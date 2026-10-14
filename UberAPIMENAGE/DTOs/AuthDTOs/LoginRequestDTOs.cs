using System.ComponentModel.DataAnnotations;

namespace UberAPIMENAGE.DTOs.AuthDTOs
{
    public class LoginRequestDTOs
    {
        [Required, EmailAddress]

        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
    }
}

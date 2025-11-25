using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO.Login
{
    public class LoginRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public String Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}

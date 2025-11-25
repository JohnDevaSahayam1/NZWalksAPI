using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO.Register
{
    public class RegisterRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public String Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        public String[] Roles { get; set; }
    }
}

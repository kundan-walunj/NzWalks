using System.ComponentModel.DataAnnotations;

namespace NzWalksAPI.Models.DTO
{
    public class Logindto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }    
    }
}

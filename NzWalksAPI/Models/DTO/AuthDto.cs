using System.ComponentModel.DataAnnotations;

namespace NzWalksAPI.Models.DTO
{
    public class AuthDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }    
        
        public string[] Roles { get; set; }
    }
}

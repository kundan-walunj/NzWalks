using System.ComponentModel.DataAnnotations;

namespace NzWalksAPI.Models.DTO
{
    public class CreateNewRegion
    {
        [Required]
        //[MinLength(3,ErrorMessage ="min 3 char")]
        //[MaxLength(3,ErrorMessage = "max 3 char")]
        public string Code { get; set; }
        [Required]
       // [MaxLength(100, ErrorMessage = "min 100 char")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}

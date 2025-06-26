using System.ComponentModel.DataAnnotations;

namespace NzWalksUI.Models.Dtos
{
    public class CreateRegion
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string RegionImageUrl { get; set; }
    }
}

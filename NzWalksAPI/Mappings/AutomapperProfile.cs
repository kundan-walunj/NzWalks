using AutoMapper;
using NzWalksAPI.Models.Domain;
using NzWalksAPI.Models.DTO;

namespace NzWalksAPI.Mappings
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Regions, RegionDto>().ReverseMap();
        }
    }
}

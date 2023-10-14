using AutoMapper;
using ReviewerApp.DTOs;
using ReviewerApp.Models;

namespace ReviewerApp.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pokeman, PokemanDTO>();
        }
    }
}

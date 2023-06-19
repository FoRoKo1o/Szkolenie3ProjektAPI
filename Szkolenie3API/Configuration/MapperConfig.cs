using AutoMapper;
using Szkolenie3API.Data;
using Szkolenie3API.DTO.Cat;
using Szkolenie3API.DTO.Dog;

namespace Szkolenie3API.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Dog, BaseDogDto>().ReverseMap();
            CreateMap<Dog, GetDogDto>().ReverseMap();
            CreateMap<Dog, PutDogDto>().ReverseMap();

            CreateMap<Cat, BaseCatDto>().ReverseMap();
            CreateMap<Cat, GetCatDto>().ReverseMap();
            CreateMap<Cat, PutCatDto>().ReverseMap();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WeatherServerAPI.Model;

namespace WeatherServerAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AutocompleteResponse, AutocompleteLight>()
                .ForMember(dest => dest.CityKey, opt => opt.MapFrom(src => src.Key))
                .ForMember(dest => dest.LocalizedName, opt => opt.MapFrom(src => src.LocalizedName));

            CreateMap<CurrentConditionsResponse, CurrentConditionsLight>()
                .ForMember(dest => dest.LocationKey, opt => opt.Ignore())
                .ForMember(dest => dest.WeatherText, opt => opt.MapFrom(src => src.WeatherText))
                .ForMember(dest => dest.TemperatureInCelsius, opt => opt.MapFrom(src => src.Temperature.Metric.Value));

            //CreateMap<AutocompleteLight, AutocompleteResponse>()
            //    .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.CityKey))
            //    .ForMember(dest => dest.LocalizedName, opt => opt.MapFrom(src => src.LocalizedName))
            //    .ForMember(dest => dest.Version, opt => opt.Ignore())
            //    .ForMember(dest => dest.Type, opt => opt.Ignore())
            //    .ForMember(dest => dest.Rank, opt => opt.Ignore())
            //    .ForMember(dest => dest.Country, opt => opt.Ignore())
            //    .ForMember(dest => dest.AdministrativeArea, opt => opt.Ignore());
        }
    }
}

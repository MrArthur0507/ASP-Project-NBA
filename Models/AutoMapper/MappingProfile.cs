using AutoMapper;
using Models.ApiModels;
using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TeamApi, Team>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => src.full_name))
            .ForMember(dest => dest.Conference, opt => opt.MapFrom(src => src.conference))
            .ForMember(dest => dest.Abbreviation, opt => opt.MapFrom(src => src.abbreviation))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.city))
            .ForMember(dest => dest.Division, opt => opt.MapFrom(src => src.division))
            .ForMember(dest => dest.Players, opt => opt.Ignore())
            .ForMember(dest => dest.Games, opt => opt.Ignore());
        }


    }
}


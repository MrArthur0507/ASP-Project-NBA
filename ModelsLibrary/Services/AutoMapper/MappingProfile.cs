﻿using AutoMapper;
using Models.ApiModels;
using Models.DbModels;
using Models.ViewModels;
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
            CreateMap<Player, PlayerViewModel>();
            CreateMap<Player, PlayerDetailsViewModel>()
            .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.Name))
            .ForMember(dest => dest.TeamFullname, opt => opt.MapFrom(src => src.Team.Fullname))
            .ForMember(dest => dest.TeamAbbreviation, opt => opt.MapFrom(src => src.Team.Abbreviation));

        }


    }
}


using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

namespace Application.Mapping
{
    public class MappingResult: Profile
    {
        public MappingResult()
        {
            CreateMap<RobotProcessor, MisionModel>()
                   .ForMember(dest => dest.Surface, opt => opt.MapFrom(src => src.MarsSurface.ToString()))
                   .ForMember(dest => dest.RobotsQuantity, opt => opt.MapFrom(src => src.FinalResult.Count))
                   .ForMember(dest => dest.Scents, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.MarsSurface.Scent)))
                   .ForMember(dest => dest.RobotsInputs, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.FinalResult.Select(res => res.InitialRobotPosition).ToArray())))
                   .ForMember(dest => dest.RobotsResult, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.FinalResult.Select(res => res.FinalRobotPosition).ToArray())));

            //CreateMap<List<MisionResultViewModel>, MisionModel>()
            //    .ForMember(dest => dest.RobotsQuantity, opt => opt.MapFrom(src => src.Count))
            //    .ForMember(dest => dest.RobotsInputs, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.Select(res => res.InitialRobotPosition).ToArray())))
            //    .ForMember(dest => dest.RobotsResult, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.Select(res => res.FinalRobotPosition).ToArray())));

        }
    }
}

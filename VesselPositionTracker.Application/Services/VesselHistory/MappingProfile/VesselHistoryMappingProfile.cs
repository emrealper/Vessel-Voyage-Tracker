using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VesselPositionTracker.Application.Services.Fleet.Commands;
using VesselPositionTracker.Application.Services.Fleet.Dto;
using VesselPositionTracker.Application.Services.VesselHistory.Dto;
using VesselPositionTracker.Domain.Entities;

namespace VesselPositionTracker.Application.Services.VesselHistory.MappingProfiles
{
    public class VesselHistoryMappingProfile : Profile
    {
        public VesselHistoryMappingProfile()
        {

       
       
            CreateMap<VesselPositionTracker.Domain.Entities.VesselHistory, VesselHistoryDto>();

        }
    }
}

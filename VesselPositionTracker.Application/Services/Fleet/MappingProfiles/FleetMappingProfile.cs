using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VesselPositionTracker.Application.Services.Fleet.Commands;
using VesselPositionTracker.Application.Services.Fleet.Dto;
using VesselPositionTracker.Domain.Entities;

namespace VesselPositionTracker.Application.Services.Fleet.MappingProfiles
{
    public class FleetMappingProfile : Profile
    {
        public FleetMappingProfile()
        {

       
            CreateMap<CreateFleetCommand,VesselPositionTracker.Domain.Entities.Fleet>();
            CreateMap<VesselPositionTracker.Domain.Entities.Fleet, FleetDto>();

        }
    }
}

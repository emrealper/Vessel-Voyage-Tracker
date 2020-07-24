using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VesselPositionTracker.Application.Services.Vessel.Commands;
using VesselPositionTracker.Application.Services.Vessel.Dto;
using VesselPositionTracker.Domain.Entities;

namespace VesselPositionTracker.Application.Services.Vessel.MappingProfiles
{
    public class VesselMappingProfile: Profile
    {
        public VesselMappingProfile()
        {

       
            CreateMap<CreateVesselCommand,VesselPositionTracker.Domain.Entities.Vessel>()
                    .ForMember(d => (int)d.VesselTypeId, opt => opt.MapFrom(s => (int)s.VesselTypeId));
        
            
            CreateMap<VesselPositionTracker.Domain.Entities.Vessel, VesselDto>()
                .ForMember(d => (int)d.VesselTypeId, opt => opt.MapFrom(s => (int)s.VesselTypeId))
                 .ForMember(d => d.VesselTypeName, opt => opt.MapFrom(s => s.VesselTypeId));
        }
    }
}

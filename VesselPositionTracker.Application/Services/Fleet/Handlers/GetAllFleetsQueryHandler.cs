using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;

using VesselPositionTracker.Application.Common.Interfaces;

using VesselPositionTracker.Application.Tasks.Queries;

using VesselPositionTracker.Application.Services.Fleet.Dto;
using VesselPositionTracker.Application.Services.Fleet.ViewModel;

namespace VesselPositionTracker.Application.Services.Fleet.Handlers
{
   public class GetAllFleetsQueryHandler : IRequestHandler<GetAllFleetsQuery, FleetListVm>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllFleetsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<FleetListVm> Handle(GetAllFleetsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Fleets.GetAllAsync();



            var fleets= _mapper.Map<List<FleetDto>>(result);

            var vm = new FleetListVm
            {
                Fleets = fleets

            };

            return vm;
        }
    }
}

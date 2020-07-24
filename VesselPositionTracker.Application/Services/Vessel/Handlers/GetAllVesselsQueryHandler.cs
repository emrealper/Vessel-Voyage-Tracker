using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;

using VesselPositionTracker.Application.Common.Interfaces;
using VesselPositionTracker.Application.Services.Vessel.Dto;
using VesselPositionTracker.Application.Tasks.Queries;
using VesselPositionTracker.Application.Services.Vessel.ViewModel;

namespace EcoDesignAPI.Application.Services.Product.Handlers
{
   public class GetAllVesselsQueryHandler : IRequestHandler<GetAllVesselsQuery, VesselListVm>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllVesselsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<VesselListVm> Handle(GetAllVesselsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Vessels.GetAllAsync();



            var vessels= _mapper.Map<List<VesselDto>>(result);

            var vm = new VesselListVm
            {
                Vessels = vessels

            };

            return vm;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using VesselPositionTracker.Application.Tasks.Queries;
using VesselPositionTracker.Application.Services.VesselHistory.ViewModel;
using VesselPositionTracker.Application.Common.Interfaces;
using VesselPositionTracker.Application.Services.VesselHistory.Dto;
using System.Linq;

namespace EcoDesignAPI.Application.Services.Product.Handlers
{
   public class GetDateIntervalQueryHandler : IRequestHandler<GetDateIntervalQuery, VesselHistoryListVm>
    {

        private readonly IVesselHistoryRepository _vesselHistoryRepository;
        private readonly IMapper _mapper;

        public GetDateIntervalQueryHandler(IVesselHistoryRepository vesselHistoryRepository, IMapper mapper)
        {

            _vesselHistoryRepository = vesselHistoryRepository;
            _mapper = mapper;

        }

        public async Task<VesselHistoryListVm> Handle(GetDateIntervalQuery request, CancellationToken cancellationToken)
        {
            var result = await _vesselHistoryRepository.ReadByQueryAsync("query");



       

            var vesselHistory= _mapper.Map<List<VesselHistoryDto>>(result);

            var vm = new VesselHistoryListVm
            {
                VesselHistories = vesselHistory

            };

            return vm;
        }
    }
}

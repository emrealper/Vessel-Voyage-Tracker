using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VesselPositionTracker.Application.Common.Interfaces;
using VesselPositionTracker.Application.Services.Fleet.Commands;
using VesselPositionTracker.Application.Services.Vessel.Commands;
using VesselPositionTracker.Domain.Entities;

namespace VesselPositionTracker.Application.Services.Fleet.Handlers
{
    public class CreateFleetCommandHandler : IRequestHandler<CreateFleetCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFleetCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateFleetCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Fleets.Add(_mapper.Map<VesselPositionTracker.Domain.Entities.Fleet>(request));
            return result;
        }
    }
}

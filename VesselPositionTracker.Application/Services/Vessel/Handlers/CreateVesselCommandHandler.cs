using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VesselPositionTracker.Application.Common.Interfaces;
using VesselPositionTracker.Application.Services.Vessel.Commands;
using VesselPositionTracker.Domain.Entities;

namespace TaskManagementApp.Application.Tasks.Handlers
{
    public class CreateVesselCommandHandler : IRequestHandler<CreateVesselCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateVesselCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateVesselCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Vessels.Add(_mapper.Map<Vessel>(request));
            return result;
        }
    }
}

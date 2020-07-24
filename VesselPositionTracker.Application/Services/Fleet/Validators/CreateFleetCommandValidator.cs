using FluentValidation;
using VesselPositionTracker.Application.Services.Fleet.Commands;
using VesselPositionTracker.Application.Services.Vessel.Commands;

namespace TaskManagementApp.Application.Tasks.Validators
{
    public class CreateFleetCommandValidator: AbstractValidator<CreateFleetCommand>
    {
        public CreateFleetCommandValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.FleetId).NotNull().GreaterThan(0);
            RuleFor(t => t.Active).NotNull();
            RuleFor(t => t.Default).NotNull();

        }
    }
}

using FluentValidation;

using VesselPositionTracker.Application.Services.Vessel.Commands;

namespace TaskManagementApp.Application.Tasks.Validators
{
    public class CreateVesselCommandValidator: AbstractValidator<CreateVesselCommand>
    {
        public CreateVesselCommandValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.VesselId).NotNull().GreaterThan(0);
            RuleFor(t => t.Mmmsi).Must(x => x > 99999999 && x < 1000000000);
            RuleFor(t => t.Active).Must(x => x >= 0 && x < 3);

        }
    }
}

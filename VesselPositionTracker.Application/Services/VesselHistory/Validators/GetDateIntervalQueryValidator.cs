using FluentValidation;
using VesselPositionTracker.Application.Tasks.Queries;

namespace TaskManagementApp.Application.Tasks.Validators
{
    public class GetDateIntervalQueryValidator : AbstractValidator<GetDateIntervalQuery>
    {
        public GetDateIntervalQueryValidator()
        {
          
            RuleFor(t => t.Begin).LessThanOrEqualTo(x=>x.End);
            

        }
    }
}

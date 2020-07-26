using FluentValidation;
using VesselPositionTracker.Application.Tasks.Queries;

namespace TaskManagementApp.Application.Tasks.Validators
{
    public class GetDateIntervalQueryValidator : AbstractValidator<GetDateIntervalQuery>
    {
        public GetDateIntervalQueryValidator()
        {
          
            RuleFor(t => t.Begin).LessThanOrEqualTo(x=>x.End);
            RuleFor(t => t.Mmsi).Must(x => x > 99999999 && x < 1000000000);


        }
    }
}

using FluentValidation;
using VesselPositionTracker.Application.Services.VesselHistory.Queries;


namespace VesselPositionTracker.Application.Services.VesselHistory.Validators
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

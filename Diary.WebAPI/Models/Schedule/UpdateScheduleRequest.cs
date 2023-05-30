using FluentValidation;
using FluentValidation.Results;

namespace Diary.WebAPI.Models;

public class UpdateScheduleRequest
{
#region Model
public DateTime DateTime {get;set;}
public string DayOfWeek {get; set;}
public string HomeTask {get; set;}

#endregion

#region Validator
public class Validator: AbstractValidator<UpdateScheduleRequest>
{
public Validator()
{
RuleFor(x=>x.DayOfWeek)
    .MaximumLength(255).WithMessage("Length must be less than 256");
RuleFor(x=>x.DateTime)
    .InclusiveBetween(DateTime.MinValue,DateTime.Today).WithMessage("Length must be less than 256");
RuleFor(x=>x.HomeTask)
    .MaximumLength(255).WithMessage("Length must be less than 256");
}

}
#endregion
}
public static class UpdateScheduleRequestExtension
{
public static ValidationResult Validate(this UpdateScheduleRequest model)
{
return new UpdateScheduleRequest.Validator().Validate(model);
}
}
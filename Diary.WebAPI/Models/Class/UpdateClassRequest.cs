using FluentValidation;
using FluentValidation.Results;

namespace Diary.WebAPI.Models;

public class UpdateClassRequest
{
#region Model
public string Name {get;set;}

#endregion

#region Validator
public class Validator: AbstractValidator<UpdateClassRequest>
{
public Validator()
{
RuleFor(x=>x.Name)
.MaximumLength(255).WithMessage("Length must be less than 256");
}

}
#endregion
}
public static class UpdateClassRequestExtension
{
public static ValidationResult Validate(this UpdateClassRequest model)
{
return new UpdateClassRequest.Validator().Validate(model);
}
}
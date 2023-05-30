using FluentValidation;
using FluentValidation.Results;

namespace Diary.WebAPI.Models;

public class UpdatePresenceRequest
{
#region Model
public bool Value {get;set;}

#endregion

#region Validator
public class Validator: AbstractValidator<UpdatePresenceRequest>
{
public Validator()
{
RuleFor(x=>x.Value)
.NotEqual(false).WithMessage("The value must be true");
}

}
#endregion
}
public static class UpdatePresenceRequestExtension
{
public static ValidationResult Validate(this UpdatePresenceRequest model)
{
return new UpdatePresenceRequest.Validator().Validate(model);
}
}
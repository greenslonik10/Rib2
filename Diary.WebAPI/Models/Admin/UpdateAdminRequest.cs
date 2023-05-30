using FluentValidation;
using FluentValidation.Results;

namespace Diary.WebAPI.Models;

public class UpdateAdminRequest
{
#region Model
public string Login {get;set;}

#endregion

#region Validator
public class Validator: AbstractValidator<UpdateAdminRequest>
{
public Validator()
{
RuleFor(x=>x.Login)
.MaximumLength(255).WithMessage("Length must be less than 256");
}

}
#endregion
}
public static class UpdateAdminRequestExtension
{
public static ValidationResult Validate(this UpdateAdminRequest model)
{
return new UpdateAdminRequest.Validator().Validate(model);
}
}
using FluentValidation;
using FluentValidation.Results;

namespace Diary.WebAPI.Models;

public class UpdateSubjectRequest
{
#region Model
public string Name {get; set;}

#endregion

#region Validator
public class Validator: AbstractValidator<UpdateSubjectRequest>
{
public Validator()
{
RuleFor(x=>x.Name)
    .MaximumLength(255).WithMessage("Length must be less than 256");
}

}
#endregion
}
public static class UpdateSubjectRequestExtension
{
public static ValidationResult Validate(this UpdateSubjectRequest model)
{
return new UpdateSubjectRequest.Validator().Validate(model);
}
}
using FluentValidation;
using FluentValidation.Results;

namespace Diary.WebAPI.Models;

public class UpdateSchoolRequest
{
#region Model
public string Name {get; set;}

#endregion

#region Validator
public class Validator: AbstractValidator<UpdateSchoolRequest>
{
public Validator()
{
RuleFor(x=>x.Name)
    .MaximumLength(255).WithMessage("Length must be less than 256");
}

}
#endregion
}
public static class UpdateSchoolRequestExtension
{
public static ValidationResult Validate(this UpdateSchoolRequest model)
{
return new UpdateSchoolRequest.Validator().Validate(model);
}
}
using FluentValidation;
using FluentValidation.Results;

namespace Diary.WebAPI.Models;

public class UpdateTeacherRequest
{
#region Model
public string Name {get; set;}
public string Surname {get; set;}
public string Patronymic {get; set;}


#endregion

#region Validator
public class Validator: AbstractValidator<UpdateTeacherRequest>
{
public Validator()
{
RuleFor(x=>x.Name)
    .MaximumLength(255).WithMessage("Length must be less than 256");
RuleFor(x=>x.Surname)
    .MaximumLength(255).WithMessage("Length must be less than 256");
RuleFor(x=>x.Patronymic)
    .MaximumLength(255).WithMessage("Length must be less than 256");
}

}
#endregion
}
public static class UpdateTeacherRequestExtension
{
public static ValidationResult Validate(this UpdateTeacherRequest model)
{
return new UpdateTeacherRequest.Validator().Validate(model);
}
}
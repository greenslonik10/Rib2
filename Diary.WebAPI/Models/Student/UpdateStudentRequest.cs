using FluentValidation;
using FluentValidation.Results;

namespace Diary.WebAPI.Models;

public class UpdateStudentRequest
{
#region Model
public string Name {get; set;}
public string Surname {get; set;}
public string Patronymic {get; set;}


#endregion

#region Validator
public class Validator: AbstractValidator<UpdateStudentRequest>
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
public static class UpdateStudentRequestExtension
{
public static ValidationResult Validate(this UpdateStudentRequest model)
{
return new UpdateStudentRequest.Validator().Validate(model);
}
}
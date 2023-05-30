using FluentValidation;
using FluentValidation.Results;

namespace Diary.WebAPI.Models;

public class UpdateMarkRequest
{
#region Model
public int Score {get;set;}

#endregion

#region Validator
public class Validator: AbstractValidator<UpdateMarkRequest>
{
public Validator()
{
RuleFor(x=>x.Score)
.NotNull().WithMessage("Must be mark");
}

}
#endregion
}
public static class UpdateMarkRequestExtension
{
public static ValidationResult Validate(this UpdateMarkRequest model)
{
return new UpdateMarkRequest.Validator().Validate(model);
}
}
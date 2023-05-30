using FluentValidation;
using FluentValidation.Results;

namespace Diary.WebAPI.Models;

public class TeacherInClassResponse
{
#region Model
public virtual Guid TeacherID {get; set;}
public virtual Guid ClassID {get; set;}

#endregion

}
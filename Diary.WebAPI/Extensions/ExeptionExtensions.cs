using Diary.Shared.Exceptions;
using Diary.WebAPI.Models;

namespace Diary.WebAPI.Extensions;

public static class ExceptionExtensions
{
    public static ErrorResponse ToErrorResponse(this LogicException exception)
    {
        return new ErrorResponse(exception.Code!);
    }

    public static ErrorResponse ToErrorResponse(this RepositoryException exception)
    {
        return new ErrorResponse(exception.Code!);
    }
}
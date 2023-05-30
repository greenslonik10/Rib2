using Diary.Services.Models;
using IdentityModel.Client;

namespace Diary.Services.Abstract;

public interface IAuthService
{
    Task<StudentModel> RegisterUser(RegisterStudentModel model);
    Task<TokenResponse> LoginUser(LoginStudentModel model);
}
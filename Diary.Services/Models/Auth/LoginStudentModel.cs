using Diary.Entity.Models;

namespace Diary.Services.Models;

public class LoginStudentModel
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}
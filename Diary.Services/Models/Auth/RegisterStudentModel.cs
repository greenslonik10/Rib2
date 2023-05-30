using Diary.Entity.Models;

namespace Diary.Services.Models;

public class RegisterStudentModel
{
    public string PasswordHash { get; set; }
    public string Login {get; set;}
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronimyc { get; set; }
    public Guid ClassID {get; set;}
    public Guid SchoolID {get; set;}
    public Role Role { get; set; }
}
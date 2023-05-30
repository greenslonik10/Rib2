namespace Diary.Entity.Models;
public class Teacher : BaseEntity
{
    public string? PasswordHash { get; set; }
    public string? Login { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronymic { get; set; }
    public virtual ICollection<TeacherInClass>? TeacherInClass { get; set; }
    public virtual ICollection<Schedule>? Schedule { get; set; }
    public virtual Guid SchoolID { get; set; }
    public virtual School? School { get; set; }
}
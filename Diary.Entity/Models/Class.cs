namespace Diary.Entity.Models;
public class Class : BaseEntity
{
    public string? Name { get; set; }
    public virtual ICollection<TeacherInClass>? TeacherInClass { get; set; }
    public virtual Guid SchoolID { get; set; }
    public virtual School? School { get; set; }
    public virtual ICollection<Student>? Student { get; set; }
    public virtual ICollection<Schedule>? Schedule { get; set; }
}
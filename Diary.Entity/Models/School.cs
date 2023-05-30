namespace Diary.Entity.Models;
public class School : BaseEntity
{
    public string? Name { get; set; }
    public virtual ICollection<Class>? Class { get; set; } 
    public virtual ICollection<Student>? Student { get; set; }
    public virtual ICollection<Teacher>? Teacher { get; set; }
}
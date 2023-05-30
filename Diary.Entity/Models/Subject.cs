namespace Diary.Entity.Models;
public class Subject : BaseEntity
{
    public string? Name { get; set; }
    public virtual ICollection<Schedule>? Schedule { get; set; }

}
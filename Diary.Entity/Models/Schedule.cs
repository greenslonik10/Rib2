namespace Diary.Entity.Models;
public class Schedule : BaseEntity
{
    public DateTime DateTime { get; set; }
    public string? DayOfWeek { get; set; }
    public string? HomeTask { get; set; }
    public virtual ICollection<Mark>? Mark { get; set; }
    public virtual ICollection<Presence>? Presence { get; set; }
    public virtual Guid SubjectID { get; set; }
    public virtual Subject? Subject { get; set; }
    public virtual Guid ClassID { get; set; }
    public virtual Class? Class { get; set; }
    public virtual Guid TeacherID { get; set; }
    public virtual Teacher? Teacher { get; set; }
    
}
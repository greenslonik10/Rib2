namespace Diary.Entity.Models;
public class Presence : BaseEntity
{
    public bool Value { get; set; }
    public virtual Guid StudentID { get; set; }
    public virtual Student? Student { get; set; }
    public virtual Guid ScheduleID { get; set; }
    public virtual Schedule? Schedule { get; set; }
}
namespace Diary.Entity.Models;
public class Mark : BaseEntity
{
    public int Score { get; set; }
    public virtual Guid StudentID { get; set; }
    public virtual Student? Student { get; set; }
    public virtual Guid ScheduleID { get; set; }
    public virtual Schedule? Schedule { get; set; }

}
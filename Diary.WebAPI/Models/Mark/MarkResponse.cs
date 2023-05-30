namespace Diary.WebAPI.Models;
public class MarkResponse {

    public Guid Id { get; set; }
    public int Score { get; set; }
    public virtual Guid StudentID { get; set; }
    public virtual Guid ScheduleID { get; set; }
    
}
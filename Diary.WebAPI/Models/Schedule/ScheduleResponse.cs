namespace Diary.WebAPI.Models;
public class ScheduleResponse {

    public Guid Id { get; set; }
    public DateTime DateTime { get; set; }
    public string? DayOfWeek { get; set; }
    public string? HomeTask { get; set; }
    public virtual Guid SubjectID { get; set; }
    public virtual Guid ClassID { get; set; }
    public virtual Guid TeacherID { get; set; }

}
using Diary.Entity.Models;
namespace Diary.Services.Models;
public class ScheduleModel : BaseModel {

    public Guid Id { get; set; }
    public DateTime DateTime { get; set; }
    public string? DayOfWeek { get; set; }
    public string? HomeTask { get; set; }
    public virtual Guid SubjectID { get; set; }
    public virtual Guid ClassID { get; set; }
    public virtual Guid TeacherID { get; set; }

}
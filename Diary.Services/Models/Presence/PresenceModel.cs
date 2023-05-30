using Diary.Entity.Models;
namespace Diary.Services.Models;
public class PresenceModel : BaseModel {

    public Guid Id { get; set; }
    public bool Value { get; set; }
    public virtual Guid StudentID { get; set; }
    public virtual Guid ScheduleID { get; set; }

}
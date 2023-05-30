using Diary.Entity.Models;
namespace Diary.Services.Models;
public class MarkModel : BaseModel {

    public Guid Id { get; set; }
    public int Score { get; set; }
    public virtual Guid StudentID { get; set; }
    public virtual Guid ScheduleID { get; set; }
    
}
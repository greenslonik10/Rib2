using Diary.Entity.Models;
namespace Diary.Services.Models;
public class TeacherInClassModel : BaseModel {
    public virtual Guid ClassID { get; set; }
    public virtual Guid TeacherID { get; set; }

}
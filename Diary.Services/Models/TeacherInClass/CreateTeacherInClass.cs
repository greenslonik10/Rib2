namespace Diary.Services.Models;
public class CreateTeacherInClassModel {
    public virtual Guid ClassID { get; set; }
    public virtual Guid TeacherID { get; set; }

}
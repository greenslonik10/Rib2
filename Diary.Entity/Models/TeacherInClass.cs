namespace Diary.Entity.Models;
public class TeacherInClass : BaseEntity
{
    public virtual Guid ClassID { get; set; }
    public virtual Class? Class { get; set; }
    public virtual Guid TeacherID { get; set; }
    public virtual Teacher? Teacher { get; set; }
    
}
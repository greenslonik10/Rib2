using Diary.Entity.Models;
namespace Diary.Services.Models;
public class ClassModel : BaseModel {

    public Guid Id { get; set; }
    public string Name { get; set; }
    public virtual Guid SchoolID { get; set; }
    
}
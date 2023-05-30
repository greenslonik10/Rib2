using Diary.Entity.Models;
namespace Diary.Services.Models;
public class StudentModel : BaseModel {

    public Guid Id { get; set; }
    public string Login { get; set; }
    public Role Role {get;set;}
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public virtual Guid ClassID { get; set; }
    public virtual Guid SchoolID { get; set; }

}
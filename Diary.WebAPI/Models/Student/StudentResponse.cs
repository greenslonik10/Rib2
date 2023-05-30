namespace Diary.WebAPI.Models;
public class StudentResponse {

    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public virtual Guid ClassID { get; set; }
    public virtual Guid SchoolID { get; set; }

}
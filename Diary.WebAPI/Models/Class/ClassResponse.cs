namespace Diary.WebAPI.Models;
public class ClassResponse {

    public Guid Id { get; set; }
    public string Name { get; set; }
    public virtual Guid SchoolID { get; set; }
    
}
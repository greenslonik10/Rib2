using Diary.Entity.Models;
namespace Diary.Services.Models;
public class TeacherPreviewModel {

    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
        
}
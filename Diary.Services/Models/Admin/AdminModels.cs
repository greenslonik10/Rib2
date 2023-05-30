using Diary.Entity.Models;
namespace Diary.Services.Models;
public class AdminModel : BaseModel {

    public Guid Id { get; set; }
    public string? Login { get; set; }

}
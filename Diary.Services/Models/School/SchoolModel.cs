using Diary.Entity.Models;
namespace Diary.Services.Models;
public class SchoolModel : BaseModel {

    public Guid Id { get; set; }
    public string? Name { get; set; }

}
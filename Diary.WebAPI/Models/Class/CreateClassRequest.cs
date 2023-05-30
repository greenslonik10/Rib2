namespace Diary.WebAPI.Models;

public class CreateClassRequest : UpdateClassRequest {

    public Guid SchoolID{get; set;}
}
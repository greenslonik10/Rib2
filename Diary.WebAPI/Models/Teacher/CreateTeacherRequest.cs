namespace Diary.WebAPI.Models;

public class CreateTeacherRequest : UpdateTeacherRequest {

    public Guid SchoolID{get; set;}
}
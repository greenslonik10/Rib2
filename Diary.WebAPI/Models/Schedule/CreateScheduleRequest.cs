namespace Diary.WebAPI.Models;

public class CreateScheduleRequest : UpdateScheduleRequest {

    public Guid SubjectID{get; set;}
    public Guid ClassID {get; set;}
    public Guid TeacherID {get; set;}
}
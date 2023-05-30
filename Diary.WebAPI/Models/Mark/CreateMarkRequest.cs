namespace Diary.WebAPI.Models;

public class CreateMarkRequest : UpdateMarkRequest {

    public Guid StudentID{get; set;}
    public Guid ScheduleID {get; set;}
    
}
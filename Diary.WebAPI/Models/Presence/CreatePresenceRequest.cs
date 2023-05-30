namespace Diary.WebAPI.Models;

public class CreatePresenceRequest : UpdatePresenceRequest {

    public Guid StudentID{get; set;}
    public Guid ScheduleID {get; set;}
}
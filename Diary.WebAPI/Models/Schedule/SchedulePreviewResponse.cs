namespace Diary.WebAPI.Models;
public class SchedulePreviewResponse {

    public Guid Id { get; set; }
    public DateTime DateTime { get; set; }
    public string? DayOfWeek { get; set; }
    public string? HomeTask { get; set; }

}
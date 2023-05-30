using Diary.Entity.Models;
namespace Diary.Services.Models;
public class SchedulePreviewModel {

    public Guid Id { get; set; }
    public DateTime DateTime { get; set; }
    public string? DayOfWeek { get; set; }
    public string? HomeTask { get; set; }

}
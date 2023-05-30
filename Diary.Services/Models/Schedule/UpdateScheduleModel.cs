using Diary.Entity.Models;
namespace Diary.Services.Models;
public class UpdateScheduleModel {

    public DateTime DateTime { get; set; }
    public string? DayOfWeek { get; set; }
    public string? HomeTask { get; set; }

}
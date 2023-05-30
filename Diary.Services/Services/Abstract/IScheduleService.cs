using Diary.Services.Models;

namespace Diary.Services.Abstract;

public interface IScheduleService
{
    ScheduleModel GetSchedule(Guid id);

    ScheduleModel UpdateSchedule(Guid id, UpdateScheduleModel schedule);

    void DeleteSchedule(Guid id);

    PageModel<SchedulePreviewModel> GetSchedules(int limit = 20, int offset = 0);

    ScheduleModel CreateSchedule (ScheduleModel ScheduleModel, Guid SubjectID, Guid ClassID, Guid TeacherID);
}
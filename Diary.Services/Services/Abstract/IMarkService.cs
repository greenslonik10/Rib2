using Diary.Services.Models;

namespace Diary.Services.Abstract;

public interface IMarkService
{
    MarkModel GetMark(Guid id);

    MarkModel UpdateMark(Guid id, UpdateMarkModel mark);

    void DeleteMark(Guid id);

    PageModel<MarkPreviewModel> GetMarks(int limit = 20, int offset = 0);
    MarkModel CreateMark(MarkModel MarkModel, Guid StudentID, Guid ScheduleID);
}
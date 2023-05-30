using Diary.Services.Models;

namespace Diary.Services.Abstract;

public interface IPresenceService
{
    PresenceModel GetPresence(Guid id);

    PresenceModel UpdatePresence(Guid id, UpdatePresenceModel presence);

    void DeletePresence(Guid id);

    PageModel<PresencePreviewModel> GetPresences(int limit = 20, int offset = 0);

    PresenceModel CreatePresence (PresenceModel presenceModel, Guid StudentID, Guid ScheduleID);
}
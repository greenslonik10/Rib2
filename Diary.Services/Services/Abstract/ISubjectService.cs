using Diary.Services.Models;

namespace Diary.Services.Abstract;

public interface ISubjectService
{
    SubjectModel GetSubject(Guid id);

    SubjectModel UpdateSubject(Guid id, UpdateSubjectModel subject);

    void DeleteSubject(Guid id);

    PageModel<SubjectPreviewModel> GetSubjects(int limit = 20, int offset = 0);

    SubjectModel CreateSubject (SubjectModel subjectModel);
}
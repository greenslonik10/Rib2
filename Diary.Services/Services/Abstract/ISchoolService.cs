using Diary.Services.Models;

namespace Diary.Services.Abstract;

public interface ISchoolService
{
    SchoolModel GetSchool(Guid id);

    SchoolModel UpdateSchool(Guid id, UpdateSchoolModel school);

    void DeleteSchool(Guid id);

    PageModel<SchoolPreviewModel> GetSchools(int limit = 20, int offset = 0);

    SchoolModel CreateSchool(SchoolModel schoolModel);
}
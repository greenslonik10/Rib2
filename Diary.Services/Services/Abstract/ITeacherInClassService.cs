using Diary.Services.Models;

namespace Diary.Services.Abstract;

public interface ITeacherInClassService
{
    TeacherInClassModel GetTeacherInClass(Guid id);

    TeacherInClassModel UpdateTeacherInClass(Guid id, TeacherInClassModel teahcerInClass);

    void DeleteTeacherInClass(Guid id);

    PageModel<TeacherInClassModel> GetTeachersInClasses(int limit = 20, int offset = 0);

    TeacherInClassModel CreateTeacherInClass (CreateTeacherInClassModel teacherModel);
}
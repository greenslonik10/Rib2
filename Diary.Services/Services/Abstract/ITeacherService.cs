using Diary.Services.Models;

namespace Diary.Services.Abstract;

public interface ITeacherService
{
    TeacherModel GetTeacher(Guid id);

    TeacherModel UpdateTeacher(Guid id, UpdateTeacherModel teacher);

    void DeleteTeacher(Guid id);

    PageModel<TeacherPreviewModel> GetTeachers(int limit = 20, int offset = 0);

    TeacherModel CreateTeacher (TeacherModel teacherModel, Guid SchoolID);
}
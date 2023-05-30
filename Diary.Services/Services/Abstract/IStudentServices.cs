using Diary.Services.Models;

namespace Diary.Services.Abstract;

public interface IStudentService
{
    StudentModel GetStudent(Guid id);

    StudentModel UpdateStudent(Guid id, UpdateStudentModel student);

    void DeleteStudent(Guid id);

    PageModel<StudentPreviewModel> GetStudents(int limit = 20, int offset = 0);
    
}
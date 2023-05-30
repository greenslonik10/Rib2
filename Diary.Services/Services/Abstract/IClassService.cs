using Diary.Services.Models;

namespace Diary.Services.Abstract;

public interface IClassService
{
    ClassModel GetClass(Guid id);

    ClassModel UpdateClass(Guid id, UpdateClassModel clas);

    void DeleteClass(Guid id);

    PageModel<ClassPreviewModel> GetClasses(int limit = 20, int offset = 0);

    ClassModel CreateClass(ClassModel СlassModel, Guid SchoolID);
}
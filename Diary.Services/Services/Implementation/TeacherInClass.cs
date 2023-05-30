using AutoMapper;
using Diary.Entity.Models;
using Diary.Repository;
using Diary.Services.Abstract;
using Diary.Services.Models;

namespace Diary.Services.Implementation;

public class TeacherInClassService : ITeacherInClassService
{
    private readonly IRepository<TeacherInClass> teacherInClassRepository;
    private readonly IMapper mapper;
    public TeacherInClassService(IRepository<TeacherInClass> teacherRepository, IMapper mapper)
    {
        this.teacherInClassRepository = teacherInClassRepository;
        this.mapper = mapper;
    }

    public void DeleteTeacherInClass(Guid id)
    {
        var teacherInClassToDelete = teacherInClassRepository.GetById(id);
        if (teacherInClassToDelete == null)
        {
            throw new Exception("Teacher in class not found");
        }

        teacherInClassRepository.Delete(teacherInClassToDelete);
    }

    public TeacherInClassModel GetTeacherInClass(Guid id)
    {
        var teacherInClass = teacherInClassRepository.GetById(id);
        return mapper.Map<TeacherInClassModel>(teacherInClass);
    }

    public PageModel<TeacherInClassModel> GetTeachersInClasses(int limit = 20, int offset = 0)
    {
        var teachersInClasses = teacherInClassRepository.GetAll();
        int totalCount = teachersInClasses.Count();
        var chunk = teachersInClasses.OrderBy(x => x.ClassID).Skip(offset).Take(limit);

        return new PageModel<TeacherInClassModel>()
        {
            Items = mapper.Map<IEnumerable<TeacherInClassModel>>(teachersInClasses),
            TotalCount = totalCount
        };
    }

    public TeacherInClassModel UpdateTeacherInClass(Guid id, TeacherInClassModel teacherInClass)
    {
        var existingTeacherInClass = teacherInClassRepository.GetById(id);
        if (existingTeacherInClass == null)
        {
            throw new Exception("Teacher in class not found");
        }

        existingTeacherInClass.ClassID = teacherInClass.ClassID;
        existingTeacherInClass.TeacherID = teacherInClass.TeacherID;

        existingTeacherInClass = teacherInClassRepository.Save(existingTeacherInClass);
        return mapper.Map<TeacherInClassModel>(existingTeacherInClass);
    }

    TeacherInClassModel ITeacherInClassService.CreateTeacherInClass(Diary.Services.Models.CreateTeacherInClassModel teacherInClassModel)
    {
      var teacherInClass= mapper.Map<Entity.Models.TeacherInClass>(teacherInClassModel);
       return mapper.Map<TeacherInClassModel>(teacherInClassRepository.Save(teacherInClass));
    }

}
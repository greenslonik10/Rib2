using AutoMapper;
using Diary.Entity.Models;
using Diary.Repository;
using Diary.Services.Abstract;
using Diary.Services.Models;

namespace Diary.Services.Implementation;

public class TeacherService : ITeacherService
{
    private readonly IRepository<Teacher> teacherRepository;
    private readonly IRepository<School> schoolRepository;
    private readonly IMapper mapper;
    public TeacherService(IRepository<Teacher> teacherRepository, IMapper mapper)
    {
        this.teacherRepository = teacherRepository;
        this.mapper = mapper;
    }

    public void DeleteTeacher(Guid id)
    {
        var teacherToDelete = teacherRepository.GetById(id);
        if (teacherToDelete == null)
        {
            throw new Exception("Teacher not found");
        }

        teacherRepository.Delete(teacherToDelete);
    }

    public TeacherModel GetTeacher(Guid id)
    {
        var teacher = teacherRepository.GetById(id);
        return mapper.Map<TeacherModel>(teacher);
    }

    public PageModel<TeacherPreviewModel> GetTeachers(int limit = 20, int offset = 0)
    {
        var teachers = teacherRepository.GetAll();
        int totalCount = teachers.Count();
        var chunk = teachers.OrderBy(x => x.Login).Skip(offset).Take(limit);

        return new PageModel<TeacherPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<TeacherPreviewModel>>(teachers),
            TotalCount = totalCount
        };
    }

    public TeacherModel UpdateTeacher(Guid id, UpdateTeacherModel teacher)
    {
        var existingTeacher = teacherRepository.GetById(id);
        if (existingTeacher == null)
        {
            throw new Exception("Teacher not found");
        }

        existingTeacher.Name = teacher.Name;
        existingTeacher.Surname = teacher.Surname;
        existingTeacher.Patronymic = teacher.Patronymic;


        existingTeacher = teacherRepository.Save(existingTeacher);
        return mapper.Map<TeacherModel>(existingTeacher);
    }
    TeacherModel ITeacherService.CreateTeacher(Diary.Services.Models.TeacherModel teacherModel, System.Guid SchoolID)
    {
      if(teacherRepository.GetAll(x=>x.Id==teacherModel.Id).FirstOrDefault()!=null)
      {
        throw new Exception ("Attempt to create a non-unique object!");
      }
        TeacherModel createTeacher = new TeacherModel();
        createTeacher.SchoolID=teacherModel.SchoolID;
        createTeacher.Name=teacherModel.Name;
        createTeacher.Surname=teacherModel.Surname;
        createTeacher.Patronymic=teacherModel.Patronymic;
        createTeacher.Login = createTeacher.Login;
        teacherRepository.Save(mapper.Map<Teacher>(createTeacher));
        return createTeacher;

    }

}
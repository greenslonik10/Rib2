using AutoMapper;
using Diary.Entity.Models;
using Diary.Repository;
using Diary.Services.Abstract;
using Diary.Services.Models;

namespace Diary.Services.Implementation;

public class ClassService : IClassService
{
    private readonly IRepository<Class> classRepository;
    private readonly IRepository<School> schoolRepository;
    private readonly IMapper mapper;
    public ClassService(IRepository<Class> classRepository, IMapper mapper)
    {
        this.classRepository = classRepository;
        this.mapper = mapper;
    }

    public void DeleteClass(Guid id)
    {
        var classToDelete = classRepository.GetById(id);
        if (classToDelete == null)
        {
            throw new Exception("Class not found");
        }

        classRepository.Delete(classToDelete);
    }

    public ClassModel GetClass(Guid id)
    {
        var clas = classRepository.GetById(id);
        return mapper.Map<ClassModel>(clas);
    }

    public PageModel<ClassPreviewModel> GetClasses(int limit = 20, int offset = 0)
    {
        var classes = classRepository.GetAll();
        int totalCount = classes.Count();
        var chunk = classes.OrderBy(x => x.Name).Skip(offset).Take(limit);

        return new PageModel<ClassPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<ClassPreviewModel>>(classes),
            TotalCount = totalCount
        };
    }

    public ClassModel UpdateClass(Guid id, UpdateClassModel clas)
    {
        var existingClass = classRepository.GetById(id);
        if (existingClass == null)
        {
            throw new Exception("Class not found");
        }

        existingClass.Name = clas.Name;

        existingClass = classRepository.Save(existingClass);
        return mapper.Map<ClassModel>(existingClass);
    }

ClassModel IClassService.CreateClass(Diary.Services.Models.ClassModel classModel, System.Guid SchoolID)
    {
      if(classRepository.GetAll(x=>x.Id==classModel.Id).FirstOrDefault()!=null)
      {
        throw new Exception ("Attempt to create a non-unique object!");
      }
        ClassModel createClass = new ClassModel();
        createClass.SchoolID=classModel.SchoolID;
        createClass.Name=classModel.Name;
        classRepository.Save(mapper.Map<Class>(createClass));
        return createClass;

    }
}
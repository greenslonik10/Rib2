using AutoMapper;
using Diary.Entity.Models;
using Diary.Repository;
using Diary.Services.Abstract;
using Diary.Services.Models;

namespace Diary.Services.Implementation;

public class SchoolService : ISchoolService
{
    private readonly IRepository<School> schoolRepository;
    private readonly IMapper mapper;
    public SchoolService(IRepository<School> schoolRepository, IMapper mapper)
    {
        this.schoolRepository = schoolRepository;
        this.mapper = mapper;
    }

    public void DeleteSchool(Guid id)
    {
        var schoolToDelete = schoolRepository.GetById(id);
        if (schoolToDelete == null)
        {
            throw new Exception("School not found");
        }

        schoolRepository.Delete(schoolToDelete);
    }

    public SchoolModel GetSchool(Guid id)
    {
        var school = schoolRepository.GetById(id);
        return mapper.Map<SchoolModel>(school);
    }

    public PageModel<SchoolPreviewModel> GetSchools(int limit = 20, int offset = 0)
    {
        var schools = schoolRepository.GetAll();
        int totalCount = schools.Count();
        var chunk = schools.OrderBy(x => x.Name).Skip(offset).Take(limit);

        return new PageModel<SchoolPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<SchoolPreviewModel>>(schools),
            TotalCount = totalCount
        };
    }

    public SchoolModel UpdateSchool(Guid id, UpdateSchoolModel school)
    {
        var existingSchool = schoolRepository.GetById(id);
        if (existingSchool == null)
        {
            throw new Exception("School not found");
        }

        existingSchool.Name = school.Name;

        existingSchool = schoolRepository.Save(existingSchool);
        return mapper.Map<SchoolModel>(existingSchool);
    }

    SchoolModel ISchoolService.CreateSchool(Diary.Services.Models.SchoolModel schoolModel)
    {
      schoolRepository.Save(mapper.Map<Entity.Models.School>(schoolModel));
        return schoolModel;
    }
}
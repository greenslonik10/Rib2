using AutoMapper;
using Diary.Entity.Models;
using Diary.Repository;
using Diary.Services.Abstract;
using Diary.Services.Models;

namespace Diary.Services.Implementation;

public class SubjectService : ISubjectService
{
    private readonly IRepository<Subject> subjectRepository;
    private readonly IMapper mapper;
    public SubjectService(IRepository<Subject> subjectRepository, IMapper mapper)
    {
        this.subjectRepository = subjectRepository;
        this.mapper = mapper;
    }

    public void DeleteSubject(Guid id)
    {
        var subjectToDelete = subjectRepository.GetById(id);
        if (subjectToDelete == null)
        {
            throw new Exception("Subject not found");
        }

        subjectRepository.Delete(subjectToDelete);
    }

    public SubjectModel GetSubject(Guid id)
    {
        var subject = subjectRepository.GetById(id);
        return mapper.Map<SubjectModel>(subject);
    }

    public PageModel<SubjectPreviewModel> GetSubjects(int limit = 20, int offset = 0)
    {
        var subjects = subjectRepository.GetAll();
        int totalCount = subjects.Count();
        var chunk = subjects.OrderBy(x => x.Name).Skip(offset).Take(limit);

        return new PageModel<SubjectPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<SubjectPreviewModel>>(subjects),
            TotalCount = totalCount
        };
    }

    public SubjectModel UpdateSubject(Guid id, UpdateSubjectModel subject)
    {
        var existingSubject = subjectRepository.GetById(id);
        if (existingSubject == null)
        {
            throw new Exception("Subject not found");
        }

        existingSubject.Name = subject.Name;

        existingSubject = subjectRepository.Save(existingSubject);
        return mapper.Map<SubjectModel>(existingSubject);
    }

    SubjectModel ISubjectService.CreateSubject(Diary.Services.Models.SubjectModel subjectModel)
    {
      subjectRepository.Save(mapper.Map<Entity.Models.Subject>(subjectModel));
        return subjectModel;
    }
}
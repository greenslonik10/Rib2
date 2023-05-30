using AutoMapper;
using Diary.Entity.Models;
using Diary.Repository;
using Diary.Services.Abstract;
using Diary.Services.Models;

namespace Diary.Services.Implementation;

public class MarkService : IMarkService
{
    private readonly IRepository<Mark> markRepository;
    private readonly IRepository<Student> studentRepository;
    private readonly IRepository<Schedule> scheduleRepository;
    private readonly IMapper mapper;
    public MarkService(IRepository<Mark> markRepository, IMapper mapper)
    {
        this.markRepository = markRepository;
        this.mapper = mapper;
    }

    public void DeleteMark(Guid id)
    {
        var markToDelete = markRepository.GetById(id);
        if (markToDelete == null)
        {
            throw new Exception("Mark not found");
        }

        markRepository.Delete(markToDelete);
    }

    public MarkModel GetMark(Guid id)
    {
        var mark = markRepository.GetById(id);
        return mapper.Map<MarkModel>(mark);
    }

    public PageModel<MarkPreviewModel> GetMarks(int limit = 20, int offset = 0)
    {
        var marks = markRepository.GetAll();
        int totalCount = marks.Count();
        var chunk = marks.OrderBy(x => x.Score).Skip(offset).Take(limit);

        return new PageModel<MarkPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<MarkPreviewModel>>(marks),
            TotalCount = totalCount
        };
    }

    public MarkModel UpdateMark(Guid id, UpdateMarkModel mark)
    {
        var existingMark = markRepository.GetById(id);
        if (existingMark == null)
        {
            throw new Exception("Mark not found");
        }

        existingMark.Score = mark.Score;

        existingMark = markRepository.Save(existingMark);
        return mapper.Map<MarkModel>(existingMark);
    }

    MarkModel IMarkService.CreateMark(Diary.Services.Models.MarkModel MarkModel, System.Guid StudentID, System.Guid ScheduleID)
    {
      if(markRepository.GetAll(x=>x.Id==MarkModel.Id).FirstOrDefault()!=null)
      {
        throw new Exception ("Attempt to create a non-unique object!");
      }
        MarkModel createMark = new MarkModel();
        createMark.StudentID=MarkModel.StudentID;
        createMark.Score=MarkModel.Score;
        createMark.ScheduleID=MarkModel.ScheduleID;
        markRepository.Save(mapper.Map<Mark>(createMark));
        return createMark;

    }


}
using AutoMapper;
using Diary.Entity.Models;
using Diary.Repository;
using Diary.Services.Abstract;
using Diary.Services.Models;

namespace Diary.Services.Implementation;

public class StudentService : IStudentService
{
    private readonly IRepository<Student> studentRepository;
    private readonly IMapper mapper;
    public StudentService(IRepository<Student> studentRepository, IMapper mapper)
    {
        this.studentRepository = studentRepository;
        this.mapper = mapper;
    }

    public void DeleteStudent(Guid id)
    {
        var studentToDelete = studentRepository.GetById(id);
        if (studentToDelete == null)
        {
            throw new Exception("Student not found");
        }

        studentRepository.Delete(studentToDelete);
    }

    public StudentModel GetStudent(Guid id)
    {
        var student = studentRepository.GetById(id);
        return mapper.Map<StudentModel>(student);
    }

    public PageModel<StudentPreviewModel> GetStudents(int limit = 20, int offset = 0)
    {
        var students = studentRepository.GetAll();
        int totalCount = students.Count();
        var chunk = students.OrderBy(x => x.Login).Skip(offset).Take(limit);

        return new PageModel<StudentPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<StudentPreviewModel>>(students),
            TotalCount = totalCount
        };
    }

    public StudentModel UpdateStudent(Guid id, UpdateStudentModel student)
    {
        var existingStudent = studentRepository.GetById(id);
        if (existingStudent == null)
        {
            throw new Exception("Student not found");
        }

        existingStudent.Name = student.Name;
        existingStudent.Surname = student.Surname;
        existingStudent.Patronymic = student.Patronymic;

        existingStudent = studentRepository.Save(existingStudent);
        return mapper.Map<StudentModel>(existingStudent);
    }
}
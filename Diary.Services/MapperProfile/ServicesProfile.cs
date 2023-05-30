using AutoMapper;
using Diary.Entity.Models;
using Diary.Services.Models;

namespace Diary.Services.MapperProfile;

public class ServicesProfile : Profile {

    public ServicesProfile () {
        #region Student
        CreateMap<Student, StudentModel>().ReverseMap();
        CreateMap<Student, StudentPreviewModel>()
            .ForMember(x => x.Login, y => y.MapFrom(u => u.Login))
            .ForMember(x => x.Surname, y => y.MapFrom(u => u.Surname))
            .ForMember(x => x.Name, y => y.MapFrom(u => u.Name))
            .ForMember(x => x.Patronymic, y => y.MapFrom(u => u.Patronymic));
        #endregion

        #region Admin
        CreateMap<Admin, AdminModel>().ReverseMap();
        CreateMap<Admin, AdminPreviewModel>()
            .ForMember(x => x.Login, y => y.MapFrom(u => u.Login));
        #endregion

        #region Teacher
        CreateMap<Teacher, TeacherModel>().ReverseMap();
        CreateMap<Teacher, TeacherPreviewModel>()
            .ForMember(x => x.Login, y => y.MapFrom(u => u.Login))
            .ForMember(x => x.Name, y => y.MapFrom(u => u.Name))
            .ForMember(x => x.Surname, y => y.MapFrom(u => u.Surname))
            .ForMember(x => x.Patronymic, y => y.MapFrom(u => u.Patronymic));
        #endregion

        #region Class
        CreateMap<Class, ClassModel>().ReverseMap();
        CreateMap<Class, ClassPreviewModel>()
            .ForMember(x => x.Name, y => y.MapFrom(u => u.Name));
        #endregion

        #region School
        CreateMap<School, SchoolModel>().ReverseMap();
        CreateMap<School, SchoolPreviewModel>()
            .ForMember(x => x.Name, y => y.MapFrom(u => u.Name));
        #endregion

        #region Mark
        CreateMap<Mark, MarkModel>().ReverseMap();
        CreateMap<Mark, MarkPreviewModel>()
            .ForMember(x => x.Score, y => y.MapFrom(u => u.Score));
        #endregion

        #region Subject
        CreateMap<Subject, SubjectModel>().ReverseMap();
        CreateMap<Subject, SubjectPreviewModel>()
            .ForMember(x => x.Name, y => y.MapFrom(u => u.Name));
        #endregion

        #region Presence
        CreateMap<Presence, PresenceModel>().ReverseMap();
        CreateMap<Presence, PresencePreviewModel>()
            .ForMember(x => x.Value, y => y.MapFrom(u => u.Value));
        #endregion

        #region Schedule
        CreateMap<Schedule, ScheduleModel>().ReverseMap();
        CreateMap<Schedule, SchedulePreviewModel>()
            .ForMember(x => x.DateTime, y => y.MapFrom(u => u.DateTime))
            .ForMember(x => x.HomeTask, y => y.MapFrom(u => u.HomeTask))
            .ForMember(x => x.DayOfWeek, y => y.MapFrom(u => u.DayOfWeek));
        #endregion

        #region TeacherInClass
        CreateMap<TeacherInClass, TeacherInClassModel>().ReverseMap();
        #endregion

    }

}
using AutoMapper;
using Diary.WebAPI.Models;
using Diary.Services.Models;

namespace Diary.WebAPI.MapperProfile;

public class PresentationProfile : Profile
{
public PresentationProfile()
{
#region Pages

CreateMap(typeof(PageModel<>),typeof(PageResponse<>));

#endregion

#region Student

CreateMap<StudentModel, StudentResponse>().ReverseMap();
CreateMap<UpdateStudentRequest, UpdateStudentModel>().ReverseMap();
CreateMap<StudentPreviewModel, StudentPreviewResponse>().ReverseMap();
CreateMap<StudentResponse, StudentPreviewModel>().ReverseMap();

#endregion

#region Teacher

CreateMap<TeacherModel, TeacherResponse>().ReverseMap();
CreateMap<UpdateTeacherRequest, UpdateTeacherModel>().ReverseMap();
CreateMap<TeacherPreviewModel, TeacherPreviewResponse>().ReverseMap();
CreateMap<TeacherResponse, TeacherPreviewModel>().ReverseMap();

#endregion

#region Admin

CreateMap<AdminModel, AdminResponse>().ReverseMap();
CreateMap<UpdateAdminRequest, UpdateAdminModel>().ReverseMap();
CreateMap<AdminPreviewModel, AdminPreviewResponse>().ReverseMap();
CreateMap<AdminResponse, AdminPreviewModel>().ReverseMap();

#endregion

#region Class

CreateMap<ClassModel, ClassResponse>().ReverseMap();
CreateMap<UpdateClassRequest, UpdateClassModel>().ReverseMap();
CreateMap<ClassPreviewModel, ClassPreviewResponse>().ReverseMap();
CreateMap<ClassResponse, ClassPreviewModel>().ReverseMap();

#endregion

#region Mark

CreateMap<MarkModel, MarkResponse>().ReverseMap();
CreateMap<UpdateMarkRequest, UpdateMarkModel>().ReverseMap();
CreateMap<MarkPreviewModel, MarkPreviewResponse>().ReverseMap();
CreateMap<MarkResponse, MarkPreviewModel>().ReverseMap();

#endregion

#region Schedule

CreateMap<ScheduleModel, ScheduleResponse>().ReverseMap();
CreateMap<UpdateScheduleRequest, UpdateScheduleModel>().ReverseMap();
CreateMap<SchedulePreviewModel, SchedulePreviewResponse>().ReverseMap();
CreateMap<ScheduleResponse, SchedulePreviewModel>().ReverseMap();

#endregion

#region Subject

CreateMap<SubjectModel, SubjectResponse>().ReverseMap();
CreateMap<UpdateSubjectRequest, UpdateSubjectModel>().ReverseMap();
CreateMap<SubjectPreviewModel, SubjectPreviewResponse>().ReverseMap();
CreateMap<SubjectResponse, SubjectPreviewModel>().ReverseMap();

#endregion

#region School

CreateMap<SchoolModel, SchoolResponse>().ReverseMap();
CreateMap<UpdateSchoolRequest, UpdateSchoolModel>().ReverseMap();
CreateMap<SchoolPreviewModel, SchoolPreviewResponse>().ReverseMap();
CreateMap<SchoolResponse, SchoolPreviewModel>().ReverseMap();

#endregion

#region Presence

CreateMap<PresenceModel, PresenceResponse>().ReverseMap();
CreateMap<UpdatePresenceRequest, UpdatePresenceModel>().ReverseMap();
CreateMap<PresencePreviewModel, PresencePreviewResponse>().ReverseMap();
CreateMap<PresenceResponse, PresencePreviewModel>().ReverseMap();

#endregion

#region TeacherInClass

CreateMap<TeacherInClassModel, TeacherInClassResponse>().ReverseMap();

#endregion
} 
}
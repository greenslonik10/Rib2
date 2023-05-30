using Diary.Services.Abstract;
using Diary.Services.Implementation;
using Diary.Services.MapperProfile;
using Microsoft.Extensions.DependencyInjection;

namespace Diary.Services;

public static partial class ServicesExtensions
{
    public static void AddBusinessLogicConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServicesProfile));
        //services
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<ISchoolService, SchoolService>();
        services.AddScoped<IPresenceService, PresenceService>();
        services.AddScoped<IClassService, ClassService>();
        services.AddScoped<ITeacherInClassService, TeacherInClassService>();
        services.AddScoped<IMarkService, MarkService>();
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<IScheduleService, ScheduleService>();
        services.AddScoped<ISubjectService, SubjectService>();
        
    }
}
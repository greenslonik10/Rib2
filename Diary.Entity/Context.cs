using Microsoft.EntityFrameworkCore;
using Diary.Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Diary.Entity;
public class Context : IdentityDbContext<Student, UserRole, Guid>
{

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        #region Admin
        builder.Entity<Admin>().ToTable("admin");
        builder.Entity<Admin>().HasKey(x => x.Id);
        #endregion

        #region Class
        builder.Entity<Class>().ToTable("class");
        builder.Entity<Class>().HasKey(x => x.Id);
        builder.Entity<Class>().HasOne(x => x.School)
                                    .WithMany(x => x.Class)
                                .HasForeignKey(x => x.SchoolID)
                            .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region Mark
        builder.Entity<Mark>().ToTable("mark");
        builder.Entity<Mark>().HasKey(x => x.Id);
        builder.Entity<Mark>().HasOne(x => x.Schedule)
                                    .WithMany(x => x.Mark)
                                .HasForeignKey(x => x.ScheduleID)
                            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Mark>().HasOne(x => x.Student)
                                    .WithMany(x => x.Mark)
                                .HasForeignKey(x => x.StudentID)
                            .OnDelete(DeleteBehavior.Cascade);
            
        #endregion

        #region Presence
        builder.Entity<Presence>().ToTable("presence");
        builder.Entity<Presence>().HasKey(x => x.Id);
        builder.Entity<Presence>().HasOne(x => x.Schedule)
                                    .WithMany(x => x.Presence)
                                .HasForeignKey(x => x.ScheduleID)
                            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Presence>().HasOne(x => x.Student)
                                    .WithMany(x => x.Presence)
                                .HasForeignKey(x => x.StudentID)
                            .OnDelete(DeleteBehavior.Cascade);
        #endregion

        #region School
        builder.Entity<School>().ToTable("school");
        builder.Entity<School>().HasKey(x => x.Id);
        #endregion

        #region Schedule
        builder.Entity<Schedule>().ToTable("schedule");
        builder.Entity<Schedule>().HasKey(x => x.Id);
        builder.Entity<Schedule>().HasOne(x => x.Class)
                                    .WithMany(x => x.Schedule)
                                .HasForeignKey(x => x.ClassID)
                            .OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Schedule>().HasOne(x => x.Teacher)
                                    .WithMany(x => x.Schedule)
                                .HasForeignKey(x => x.TeacherID)
                            .OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Schedule>().HasOne(x => x.Subject)
                                    .WithMany(x => x.Schedule)
                                .HasForeignKey(x => x.SubjectID)
                            .OnDelete(DeleteBehavior.NoAction);
        #endregion

        #region Student
        builder.Entity<Student>().ToTable("student");
        builder.Entity<Student>().HasKey(x => x.Id);
        builder.Entity<Student>().HasOne(x => x.Class)
                                    .WithMany(x => x.Student)
                                .HasForeignKey(x => x.ClassID)
                            .OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Student>().HasOne(x => x.School)
                                    .WithMany(x => x.Student)
                                .HasForeignKey(x => x.SchoolID)
                            .OnDelete(DeleteBehavior.NoAction);
        #endregion

        #region Subject
        builder.Entity<Subject>().ToTable("subject");
        builder.Entity<Subject>().HasKey(x => x.Id);
        #endregion

        #region Teacher
        builder.Entity<Teacher>().ToTable("teacher");
        builder.Entity<Teacher>().HasKey(x => x.Id);
        builder.Entity<Teacher>().HasOne(x => x.School)
                                    .WithMany(x => x.Teacher)
                                .HasForeignKey(x => x.SchoolID)
                            .OnDelete(DeleteBehavior.Cascade);
        #endregion

        #region TeacherInClass
        builder.Entity<TeacherInClass>().ToTable("teacherInClass");
        builder.Entity<TeacherInClass>().HasKey(x => x.Id);
        builder.Entity<TeacherInClass>().HasOne(x => x.Class)
                                    .WithMany(x => x.TeacherInClass)
                                .HasForeignKey(x => x.ClassID)
                            .OnDelete(DeleteBehavior.NoAction);
        builder.Entity<TeacherInClass>().HasOne(x => x.Teacher)
                                    .WithMany(x => x.TeacherInClass)
                                .HasForeignKey(x => x.TeacherID)
                            .OnDelete(DeleteBehavior.NoAction);
        #endregion


    }
}


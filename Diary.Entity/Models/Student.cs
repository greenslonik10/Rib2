using Microsoft.AspNetCore.Identity;
namespace Diary.Entity.Models;

public class Student : IdentityUser<Guid>, IBaseEntity
{
    public string? PasswordHash { get; set; }
    public string? Login { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronymic { get; set; }
    public virtual ICollection<Mark>? Mark { get; set; }
    public virtual Guid ClassID { get; set; }
    public virtual Class? Class { get; set; }
    public virtual Guid SchoolID { get; set; }
    public virtual School? School { get; set; }
    public virtual ICollection<Presence>? Presence { get; set; } 
    public Role Role { get; set; }
    
    #region BaseEntity

    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }

    public bool IsNew()
    {
        return Id == Guid.Empty;
    }

    public void Init()
    {
        Id = Guid.NewGuid();
        CreationTime = DateTime.UtcNow;
        ModificationTime = DateTime.UtcNow;
    }

    #endregion

}

public class UserRole : IdentityRole<Guid>
{ }

namespace Diary.Entity.Models;
public class Admin : BaseEntity
{
    public string? PasswordHash { get; set; }
    public string? Login { get; set; }

}
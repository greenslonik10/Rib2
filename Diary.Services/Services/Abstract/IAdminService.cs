using Diary.Services.Models;

namespace Diary.Services.Abstract;

public interface IAdminService
{
    AdminModel GetAdmin(Guid id);

    AdminModel UpdateAdmin(Guid id, UpdateAdminModel admin);

    void DeleteAdmin(Guid id);

    PageModel<AdminPreviewModel> GetAdmins(int limit = 20, int offset = 0);

    AdminModel CreateAdmin(AdminModel adminModel);
}
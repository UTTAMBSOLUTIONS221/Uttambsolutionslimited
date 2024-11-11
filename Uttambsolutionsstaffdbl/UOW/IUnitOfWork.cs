using Uttambsolutionsstaffdbl.Repositories;

namespace Uttambsolutionsstaffdbl.UOW
{
    public interface IUnitOfWork
    {
        IPermissionRepository PermissionRepository { get; }
        IRoleRepository RoleRepository { get; }
        IStaffRepository StaffRepository { get; }
        IAuthRepository AuthRepository { get; }
    }
}

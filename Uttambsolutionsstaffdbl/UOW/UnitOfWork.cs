using Uttambsolutionsstaffdbl.Repositories;

namespace Uttambsolutionsstaffdbl.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private string connString;
        private bool _disposed;

        private IPermissionRepository permissionRepository;
        private IRoleRepository roleRepository;
        private IStaffRepository staffRepository;
        private IAuthRepository authRepository;
        public UnitOfWork(string connectionString) => connString = connectionString;
        public IPermissionRepository PermissionRepository
        {
            get { return permissionRepository ?? (permissionRepository = new PermissionRepository(connString)); }
        }
        public IRoleRepository RoleRepository
        {
            get { return roleRepository ?? (roleRepository = new RoleRepository(connString)); }
        }
        public IStaffRepository StaffRepository
        {
            get { return staffRepository ?? (staffRepository = new StaffRepository(connString)); }
        }
        public IAuthRepository AuthRepository
        {
            get { return authRepository ?? (authRepository = new AuthRepository(connString)); }
        }

        public void Reset()
        {
            permissionRepository = null;
            roleRepository = null;
            staffRepository = null;
            authRepository = null;
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}

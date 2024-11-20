using Uttambsolutionsvehiclesdbl.Repositories;

namespace Uttambsolutionsvehiclesdbl.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private string connString;
        private bool _disposed;

        private IVehiclemakeRepository vehiclemakeRepository;
        private IVehiclemodelRepository vehiclemodelRepository;
        public UnitOfWork(string connectionString) => connString = connectionString;
        public IVehiclemakeRepository VehiclemakeRepository
        {
            get { return vehiclemakeRepository ?? (vehiclemakeRepository = new VehiclemakeRepository(connString)); }
        }
        public IVehiclemodelRepository VehiclemodelRepository
        {
            get { return vehiclemodelRepository ?? (vehiclemodelRepository = new VehiclemodelRepository(connString)); }
        }

        public void Reset()
        {
            vehiclemakeRepository = null;
            vehiclemodelRepository = null;
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

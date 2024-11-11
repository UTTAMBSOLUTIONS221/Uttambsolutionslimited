using Uttambsolutionscustomerdbl.Repositories;

namespace Uttambsolutionscustomerdbl.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private string connString;
        private bool _disposed;

        private ICustomerRepository customerRepository;
        public UnitOfWork(string connectionString) => connString = connectionString;
        public ICustomerRepository CustomerRepository
        {
            get { return customerRepository ?? (customerRepository = new CustomerRepository(connString)); }
        }


        public void Reset()
        {
            customerRepository = null;
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

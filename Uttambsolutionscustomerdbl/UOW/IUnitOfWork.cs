using Uttambsolutionscustomerdbl.Repositories;

namespace Uttambsolutionscustomerdbl.UOW
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
    }
}

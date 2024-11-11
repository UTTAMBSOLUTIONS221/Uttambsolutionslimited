using Uttambsolutionscustomerdbl.Entities;
using Uttambsolutionscustomerdbl.Models;

namespace Uttambsolutionscustomerdbl.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Uttambsolutionscustomers> Getuttambsolutionscustomerdata();
        Genericmodel Registeruttambsolutionscustomerdata(string JsonData);
        Uttambsolutionscustomers Getuttambsolutionscustomerdatabyid(long Customerid);
    }
}

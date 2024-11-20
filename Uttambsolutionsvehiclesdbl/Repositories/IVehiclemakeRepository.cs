using Uttambsolutionsvehiclesdbl.Entities;
using Uttambsolutionsvehiclesdbl.Models;

namespace Uttambsolutionsvehiclesdbl.Repositories
{
    public interface IVehiclemakeRepository
    {
        IEnumerable<Uttambsolutionsvehiclemake> Getuttambsolutionsvehiclemakedata();
        Genericmodel Registeruttambsolutionsvehiclemakedata(string JsonData);
        Uttambsolutionsvehiclemake Getuttambsolutionsvehiclemakedatabyid(long Vehiclemakeid);
    }
}

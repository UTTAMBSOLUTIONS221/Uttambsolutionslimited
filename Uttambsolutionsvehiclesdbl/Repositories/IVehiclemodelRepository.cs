using Uttambsolutionsvehiclesdbl.Entities;
using Uttambsolutionsvehiclesdbl.Models;

namespace Uttambsolutionsvehiclesdbl.Repositories
{
    public interface IVehiclemodelRepository
    {
        IEnumerable<Uttambsolutionsvehiclemodel> Getuttambsolutionsvehiclemodeldata();
        Genericmodel Registeruttambsolutionsvehiclemodeldata(string JsonData);
        Uttambsolutionsvehiclemodel Getuttambsolutionsvehiclemodeldatabyid(long Vehiclemodelid);
    }
}

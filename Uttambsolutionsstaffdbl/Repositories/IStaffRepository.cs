using Uttambsolutionsstaffdbl.Entities;
using Uttambsolutionsstaffdbl.Models;

namespace Uttambsolutionsstaffdbl.Repositories
{
    public interface IStaffRepository
    {
        IEnumerable<Uttambsolutionsstaffs> Getuttambsolutionsstaffdata();
        Genericmodel Registeruttambsolutionsstaffdata(string JsonData);
        Uttambsolutionsstaffs Getuttambsolutionsstaffdatabyid(long Staffid);
    }
}

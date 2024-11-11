using Uttambsolutionsstaffdbl.Entities;
using Uttambsolutionsstaffdbl.Models;

namespace Uttambsolutionsstaffdbl.Repositories
{
    public interface IPermissionRepository
    {
        IEnumerable<Uttambsolutionspermission> Getuttambsolutionspermissiondata();
        Genericmodel Registeruttambsolutionspermissiondata(string JsonData);
        Uttambsolutionspermission Getuttambsolutionspermissiondatabyid(long Permissionid);
    }
}

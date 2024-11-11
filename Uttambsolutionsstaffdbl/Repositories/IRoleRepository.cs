using Uttambsolutionsstaffdbl.Entities;
using Uttambsolutionsstaffdbl.Models;

namespace Uttambsolutionsstaffdbl.Repositories
{
    public interface IRoleRepository
    {
        IEnumerable<Uttambsolutionsrole> Getuttambsolutionsroledata();
        Genericmodel Registeruttambsolutionsroledata(string JsonData);
        Uttambsolutionsrole Getuttambsolutionsroledatabyid(long Roleid);
    }
}

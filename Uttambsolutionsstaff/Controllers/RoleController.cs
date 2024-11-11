using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Uttambsolutionsstaffdbl;
using Uttambsolutionsstaffdbl.Entities;
using Uttambsolutionsstaffdbl.Models;

namespace Uttambsolutionsstaff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public RoleController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
        }
        [HttpGet("Getuttambsolutionsroledata")]
        public async Task<IEnumerable<Uttambsolutionsrole>> Getuttambsolutionsroledata()
        {
            return await bl.Getuttambsolutionsroledata();
        }
        [HttpPost("Registeruttambsolutionsroledata")]
        public async Task<Genericmodel> Registeruttambsolutionsroledata(Uttambsolutionsrole obj)
        {
            return await bl.Registeruttambsolutionsroledata(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getuttambsolutionsroledatabyid{Roleid}")]
        public async Task<Uttambsolutionsrole> Getuttambsolutionsroledatabyid(int Roleid)
        {
            return await bl.Getuttambsolutionsroledatabyid(Roleid);
        }
    }
}

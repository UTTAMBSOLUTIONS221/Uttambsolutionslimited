using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Uttambsolutionsstaffdbl;
using Uttambsolutionsstaffdbl.Entities;
using Uttambsolutionsstaffdbl.Models;

namespace Uttambsolutionsstaff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public PermissionController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
        }

        [HttpGet("Getuttambsolutionspermissiondata")]
        public async Task<IEnumerable<Uttambsolutionspermission>> Getuttambsolutionspermissiondata()
        {
            return await bl.Getuttambsolutionspermissiondata();
        }
        [HttpPost("Registeruttambsolutionspermissiondata")]
        public async Task<Genericmodel> Registeruttambsolutionspermissiondata(Uttambsolutionspermission obj)
        {
            return await bl.Registeruttambsolutionspermissiondata(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getuttambsolutionspermissiondatabyid{Permissionid}")]
        public async Task<Uttambsolutionspermission> Getuttambsolutionspermissiondatabyid(int Permissionid)
        {
            return await bl.Getuttambsolutionspermissiondatabyid(Permissionid);
        }
    }
}

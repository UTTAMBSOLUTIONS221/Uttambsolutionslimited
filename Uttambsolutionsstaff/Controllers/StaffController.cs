using Microsoft.AspNetCore.Mvc;
using Uttambsolutionsstaffdbl;
using Uttambsolutionsstaffdbl.Entities;
using Uttambsolutionsstaffdbl.Models;

namespace Uttambsolutionsstaff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public StaffController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
        }
        [HttpGet("Getuttambsolutionsstaffdata")]
        public async Task<IEnumerable<Uttambsolutionsstaffs>> Getuttambsolutionsstaffdata()
        {
            return await bl.Getuttambsolutionsstaffdata();
        }
        [HttpPost("Registeruttambsolutionsstaffdata")]
        public async Task<Genericmodel> Registeruttambsolutionsstaffdata(Uttambsolutionsstaffs obj)
        {
            return await bl.Registeruttambsolutionsstaffdata(obj);
        }
        [HttpGet("Getuttambsolutionsstaffdatabyid{Staffid}")]
        public async Task<Uttambsolutionsstaffs> Getuttambsolutionsstaffdatabyid(int Staffid)
        {
            return await bl.Getuttambsolutionsstaffdatabyid(Staffid);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Uttambsolutionsvehiclesdbl;
using Uttambsolutionsvehiclesdbl.Entities;
using Uttambsolutionsvehiclesdbl.Models;

namespace Uttambsolutionsvehicles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclemakeController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public VehiclemakeController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
        }
        [HttpGet("Getuttambsolutionsvehiclemakedata")]
        public async Task<IEnumerable<Uttambsolutionsvehiclemake>> Getuttambsolutionsvehiclemakedata()
        {
            return await bl.Getuttambsolutionsvehiclemakedata();
        }
        [HttpPost("Registeruttambsolutionsvehiclemakedata")]
        public async Task<Genericmodel> Registeruttambsolutionsvehiclemakedata(Uttambsolutionsvehiclemake obj)
        {
            return await bl.Registeruttambsolutionsvehiclemakedata(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getuttambsolutionsvehiclemakedatabyid{Vehiclemakeid}")]
        public async Task<Uttambsolutionsvehiclemake> Getuttambsolutionsvehiclemakedatabyid(int Vehiclemakeid)
        {
            return await bl.Getuttambsolutionsvehiclemakedatabyid(Vehiclemakeid);
        }
    }
}

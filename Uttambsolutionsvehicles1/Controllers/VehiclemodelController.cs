using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Uttambsolutionsvehiclesdbl;
using Uttambsolutionsvehiclesdbl.Entities;
using Uttambsolutionsvehiclesdbl.Models;

namespace Uttambsolutionsvehicles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclemodelController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public VehiclemodelController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
        }
        [HttpGet("Getuttambsolutionsvehiclemodeldata")]
        public async Task<IEnumerable<Uttambsolutionsvehiclemodel>> Getuttambsolutionsvehiclemodeldata()
        {
            return await bl.Getuttambsolutionsvehiclemodeldata();
        }
        [HttpPost("Registeruttambsolutionsvehiclemodeldata")]
        public async Task<Genericmodel> Registeruttambsolutionsvehiclemodeldata(Uttambsolutionsvehiclemodel obj)
        {
            return await bl.Registeruttambsolutionsvehiclemodeldata(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getuttambsolutionsvehiclemodeldatabyid{Vehiclemodelid}")]
        public async Task<Uttambsolutionsvehiclemodel> Getuttambsolutionsvehiclemodeldatabyid(int Vehiclemodelid)
        {
            return await bl.Getuttambsolutionsvehiclemodeldatabyid(Vehiclemodelid);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Uttambsolutionscustomerdbl;
using Uttambsolutionscustomerdbl.Entities;
using Uttambsolutionscustomerdbl.Models;

namespace Uttambsolutionscustomer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public CustomerController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
        }

        [HttpGet("Getuttambsolutionscustomerdata")]
        public async Task<IEnumerable<Uttambsolutionscustomers>> Getuttambsolutionscustomerdata()
        {
            return await bl.Getuttambsolutionscustomerdata();
        }
        [HttpPost("Registeruttambsolutionscustomerdata")]
        public async Task<Genericmodel> Registeruttambsolutionscustomerdata(Uttambsolutionscustomers obj)
        {
            return await bl.Registeruttambsolutionscustomerdata(obj);
        }
        [HttpGet("Getuttambsolutionscustomerdatabyid{Customerid}")]
        public async Task<Uttambsolutionscustomers> Getuttambsolutionscustomerdatabyid(int Customerid)
        {
            return await bl.Getuttambsolutionscustomerdatabyid(Customerid);
        }
    }
}

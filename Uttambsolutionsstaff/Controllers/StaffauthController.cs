using Microsoft.AspNetCore.Mvc;
using Uttambsolutionsstaffdbl;
using Uttambsolutionsstaffdbl.Entities;
using Uttambsolutionsstaffdbl.Models;

namespace Uttambsolutionsstaff.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffauthController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public StaffauthController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
        }

        [HttpPost("Staffauthenticate")]
        public async Task<Uttambsolutionsstaffresponce> AuthenticateAsync([FromBody] Uttambsolurionsstaffauth userdata)
        {
            var Authenticationresponse = await bl.Validateuttambsolutionsstaffdata(userdata);

            return Authenticationresponse;
        }
    }
}

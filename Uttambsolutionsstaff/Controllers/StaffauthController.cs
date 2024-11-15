using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Uttambsolutionsstaffdbl;
using Uttambsolutionsstaffdbl.Entities;
using Uttambsolutionsstaffdbl.Models;

namespace Uttambsolutionsstaff.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowReactApp")] // Attach the CORS policy here
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

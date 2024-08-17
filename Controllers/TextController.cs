using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestForServer.Models;

namespace TestForServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
        [HttpPost]
        public IActionResult Index(TextDto req)
        {
            return Ok(new
            {
                req,
                nn = Guid.NewGuid().ToString()
            });
        }
    }
}

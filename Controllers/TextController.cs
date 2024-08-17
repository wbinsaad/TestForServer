using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestForServer.Database;
using TestForServer.Models;
using TestForServer.ModelViews;

namespace TestForServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public TextController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<OkObjectResult> Get()
        {
            var query = await _appDbContext
                                       .Texts
                                       .AsNoTracking()
                                       .ToListAsync();

            return Ok(query);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TextDto req)
        {
            var reqMapped = _mapper.Map<Text>(req);
            if (reqMapped is null) return BadRequest("something went wrong");
            
            reqMapped.IPAddress = HttpContext.Request.Host.Host;

            await _appDbContext.AddAsync(reqMapped);
            await _appDbContext.SaveChangesAsync();

            return Ok(reqMapped);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid? Id)
        {
            if(Id is null) return NotFound();

            var query = await _appDbContext.Texts.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (query is null) return NotFound();

            _appDbContext.Remove(query);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}

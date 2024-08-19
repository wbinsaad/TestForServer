using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestForServer.Database;

namespace TestForServer.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;


        public DashboardController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpGet("TextBySender")]
        public async Task<IActionResult> TextBySender()
        {
            var query = await _appDbContext
                                                                .Texts
                                                                .GroupBy(x => x.sender)
                                                                .Select(text => new
                                                                {
                                                                    text.Key,
                                                                    NumberOfText = text.Count()
                                                                })
                                                                .AsNoTracking()
                                                                .ToListAsync();

            return Ok(query);
        }

        [HttpGet("TextByMonth")]
        public async Task<IActionResult> TextByMonth()
        {
            var query = await _appDbContext.Texts
                                                    .GroupBy(x => new { x.CreateDate.Year, x.CreateDate.Month })
                                                    .Select(text => new
                                                    {
                                                        text.Key,
                                                        NumberOfText = text.Count()
                                                    })
                                                    .AsNoTracking()
                                                    .ToListAsync();

            return Ok(query);
        }
    }
}

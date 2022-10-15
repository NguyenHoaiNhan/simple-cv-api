using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCV.Data.EF;
using SimpleCV.Data.Entities;

namespace SimpleCV.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class CvController : ControllerBase
    {
        private readonly PgDbContext _context;

        public CvController(PgDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<User>> Get() => await _context.Users.ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var cv = await _context.Users.FindAsync(id);
            return cv == null ? NotFound() : Ok(cv);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    id = user.Id
                },
                user
            );
        }
    }
}
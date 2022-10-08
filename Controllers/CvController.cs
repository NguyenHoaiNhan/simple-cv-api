using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCV.Data;
using SimpleCV.Models;

namespace SimpleCV.Controllers
{
    [Route("api/cv")]
    [ApiController]
    public class CvController : ControllerBase
    {
        private readonly CvDbContext _context;
        public CvController(CvDbContext context) => _context = context;

        [HttpGet]
        [Route("users")]
        public async Task<IEnumerable<Users>> Get() => await _context.Users.ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(Users), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var cv = await _context.Users.FindAsync(id);
            return cv == null ? NotFound() : Ok(cv);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    id = user.userId
                },
                user
            );
        }
    }
}
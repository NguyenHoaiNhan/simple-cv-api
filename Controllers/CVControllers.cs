using Microsoft.AspNetCore.Mvc;
using SimpleCV.Data.DTO.CV;
using SimpleCV.Services.IServices;

namespace SimpleCV.Controllers
{
    [Route("api/cv")]
    [ApiController]
    public class CVController : ControllerBase
    {
        private readonly ICVService _cvService;

        public CVController(ICVService cvService)
        {
            _cvService = cvService;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCV(int id)
        {
            try 
            {
                return Ok(await _cvService.GetCV(id));
            }
            catch(Exception)
            {
                return BadRequest("Get CV failed");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCV(CVDTO cv)
        {
            try
            {
                return Ok(await _cvService.AddCV(cv));
            }
            catch(Exception)
            {
                return BadRequest("Add CV failed");
            }
        }
    }
}
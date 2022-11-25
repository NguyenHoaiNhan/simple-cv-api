using Microsoft.AspNetCore.Mvc;
using SimpleCV.Data.DTO.CV;
using SimpleCV.Services.IServices;

namespace SimpleCV.Controllers
{
    [Route("API/CV")]
    [ApiController]
    public class CVController : ControllerBase
    {
        private readonly ICVService _cvService;

        public CVController(ICVService cvService)
        {
            _cvService = cvService;
        }
        
        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetCVs(int accountId)
        {
            try
            {
                return Ok(await _cvService.GetCVs(accountId));
            }
            catch(Exception)
            {
                return BadRequest("Get list CVs failed");
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

        [HttpDelete]
        public async Task<IActionResult> DeleteCV(int cvId)
        {
            try
            {
                await _cvService.DeleteCV(cvId);
                return Ok();
            }
            catch(Exception)
            {
                return BadRequest("Delete CV failed");
            }
        }
    }
}
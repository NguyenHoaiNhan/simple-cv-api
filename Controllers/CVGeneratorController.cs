using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SimpleCV.Data.DTO.CVGenerator;
using SimpleCV.Services.IServices;

namespace SimpleCV.Controllers
{
    [Route("API/CVGenerator/[action]")]
    [ApiController]
    public class CVGeneratorController : ControllerBase
    {
        private readonly ICVGeneratorService _cvGeneratorService;

        public CVGeneratorController(ICVGeneratorService cvGeneratorService)
        {
            _cvGeneratorService = cvGeneratorService;
        }

        [ActionName("GetPersonalInfo")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonalInfoSection(int id)
        {
            try
            {
                return Ok(await _cvGeneratorService.GetPersonalInfo(id));
            }
            catch (Exception)
            {
                return BadRequest("Get info failed");
            }
        }

        [ActionName("AddPersonalInfo")]
        [HttpPost]
        public async Task<IActionResult> AddPersonalInfoSection(PersonalInfoDTO info)
        {
            try
            {
                return Ok(await _cvGeneratorService.AddPersonalInfo(info));
            }
            catch (Exception)
            {
                return BadRequest("Add information failed");
            }
        }

        [ActionName("UpdatePersonalInfo")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePersonalInfoSection(int id, JsonPatchDocument<PersonalInfoDTO> info)
        {
            try
            {
                var InfoToUpdate = await _cvGeneratorService.GetPersonalInfo(id);
                info.ApplyTo(InfoToUpdate);
                await _cvGeneratorService.UpdatePersonalInfo(InfoToUpdate);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [ActionName("GetSkillTypes")]
        [HttpGet]
        public async Task<IActionResult> GetSkillTypes(string skillType)
        {
            try
            {
                return Ok(await _cvGeneratorService.GetSkillTypes(skillType));
            }
            catch (Exception)
            {
                return BadRequest("Get all skill types failed");
            }
        }

        [ActionName("GetSkillsOfCV")]
        [HttpGet]
        public async Task<IActionResult> GetSkillsOfCV(int cvId, string skillType)
        {
            try
            {
                return Ok(await _cvGeneratorService.GetSkillsOfCV(cvId, skillType));
            }
            catch (Exception)
            {
                return BadRequest("Get technical skills failed");
            }
        }

        [ActionName("AddSkill")]
        [HttpPost("{cvId}")]
        public async Task<IActionResult> AddSkill(int cvId, SkillDTO skill)
        {
            try
            {
                return Ok(await _cvGeneratorService.AddSkill(cvId, skill));
            }
            catch (Exception)
            {
                return BadRequest("Add skill failed");
            }
        }

        [ActionName("UpdateSkill")]
        [HttpPatch]
        public async Task<IActionResult> UpdateSkill(int cvId, int oldSkillId, JsonPatchDocument<SkillDTO> skill)
        {
            try
            {
                var technicalSkill = await _cvGeneratorService.GetSkill(oldSkillId, cvId);
                skill.ApplyTo(technicalSkill);
                await _cvGeneratorService.UpdateSkill(cvId, oldSkillId, technicalSkill);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Update technical skill failed");
            }
        }

        [ActionName("DeleteSkill")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSkill(int skillId, int cvId)
        {
            try
            {
                await _cvGeneratorService.DeleteSkill(skillId, cvId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Delete technical skill failed");
            }
        }

        [ActionName("GetActivitiesOfCV")]
        [HttpGet]
        public async Task<IActionResult> GetActivitiesOfCV(int cvId, string activityType)
        {
            try
            {
                return Ok(await _cvGeneratorService.GetActivitiesOfCV(cvId, activityType));
            }
            catch (Exception)
            {
                return BadRequest("Get activities of cv failed");
            }
        }

        [ActionName("GetActivity")]
        [HttpGet("{activityId}")]
        public async Task<IActionResult> GetActivity(int activityId)
        {
            try
            {
                return Ok(await _cvGeneratorService.GetActivity(activityId));
            }
            catch (Exception)
            {
                return BadRequest("Get activity failed");
            }
        }

        [ActionName("AddActivity")]
        [HttpPost]
        public async Task<IActionResult> AddActivity(ActivityDTO activity)
        {
            try
            {
                return Ok(await _cvGeneratorService.AddActivity(activity));
            }
            catch (Exception)
            {
                return BadRequest("Add activity failed");
            }
        }

        [ActionName("UpdateActivity")]
        [HttpPatch]
        public async Task<IActionResult> UpdateEducation(int activityId, JsonPatchDocument<ActivityDTO> activity)
        {
            try
            {
                var activityToUpdate = await _cvGeneratorService.GetActivity(activityId);
                activity.ApplyTo(activityToUpdate);
                await _cvGeneratorService.UpdateActivity(activityToUpdate);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Update activity failed");
            }
        }

        [ActionName("DeleteActivity")]
        [HttpDelete]
        public async Task<IActionResult> DeleteActivity(int activityId)
        {
            try
            {
                await _cvGeneratorService.DeleteActivity(activityId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Delete activity failed");
            }
        }
    }
}
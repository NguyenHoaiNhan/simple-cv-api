using SimpleCV.Data.DTO.CVGenerator;

namespace SimpleCV.Services.IServices
{
    public interface ICVGeneratorService
    {
        Task<PersonalInfoDTO> GetPersonalInfo(int id);

        Task<PersonalInfoDTO> AddPersonalInfo(PersonalInfoDTO infoToAdd);

        Task UpdatePersonalInfo(PersonalInfoDTO infoToUpdate);

        Task<List<SkillTypeDTO>> GetSkillTypes(string skillType);

        Task<List<SkillDTO>> GetSkillsOfCV(int cvId, string skillType);

        Task<SkillDTO> GetSkill(int skillId, int cvId);

        Task<SkillDTO> AddSkill(int cvId, SkillDTO skillToAdd);

        Task UpdateSkill(int cvId, int oldSkillId, SkillDTO skillToUpdate);

        Task DeleteSkill(int skillId, int cvId);

        Task<ActivityDTO> GetActivity(int activityId);

        Task<List<ActivityDTO>> GetActivitiesOfCV(int cvId, string activityType);

        Task<ActivityDTO> AddActivity(ActivityDTO activity);

        Task UpdateActivity(ActivityDTO activity);

        Task DeleteActivity(int activityId);
    }
}
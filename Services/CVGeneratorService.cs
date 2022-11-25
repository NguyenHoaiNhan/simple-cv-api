using AutoMapper;
using SimpleCV.Data.DTO.CVGenerator;
using SimpleCV.Data.Entities;
using SimpleCV.Data.Models;
using SimpleCV.Data.Repositories.IRepositories;
using SimpleCV.Services.IServices;

namespace SimpleCV.Services
{
    public class CVGeneratorService : ICVGeneratorService
    {
        private readonly IMapper _mapper;
        private readonly IInfoRepository _infoRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly ICVSkillRepository _cvSkillRepository;
        private readonly IActivityRepository _activityRepository;
        private readonly IDescriptionRepository _descriptionRepository;

        public CVGeneratorService(
            IMapper mapper,
            IInfoRepository infoRepository,
            ISkillRepository skillRepository,
            ICVSkillRepository cVSkillRepository,
            IActivityRepository activityRepository,
            IDescriptionRepository descriptionRepository
        )
        {
            _mapper = mapper;
            _infoRepository = infoRepository;
            _skillRepository = skillRepository;
            _cvSkillRepository = cVSkillRepository;
            _activityRepository = activityRepository;
            _descriptionRepository = descriptionRepository;
        }

        public async Task<PersonalInfoDTO> AddPersonalInfo(PersonalInfoDTO info)
        {
            var infoToAdd = _mapper.Map<Info>(info);
            return _mapper.Map<PersonalInfoDTO>(
                await _infoRepository.Add(infoToAdd)
            );
        }

        public async Task<PersonalInfoDTO> GetPersonalInfo(int id)
        {
            return _mapper.Map<PersonalInfoDTO>(
                await _infoRepository.Get(x => x.CVId == id)
            );
        }

        public async Task UpdatePersonalInfo(PersonalInfoDTO info)
        {
            var infoToCheck = await _infoRepository.Get(x => x.CVId == info.CVId);
            var infoToUpdate = _mapper.Map<Info>(info);

            if (infoToCheck == null)
            {
                await this.AddPersonalInfo(info);
                return;
            }

            await _infoRepository.Update(infoToUpdate);
        }

        public async Task<ActivityDTO> GetActivity(int activityId)
        {
            var properActivity = await _activityRepository.Get(x => x.ActId == activityId);
            if(properActivity == null)
                return null;
            
            var result = _mapper.Map<ActivityDTO>(properActivity);
            result.Description = _mapper.Map<TextForm>(
                await _descriptionRepository.Get(x => x.ActivityId == activityId)
            );
            return result;
        }

        public async Task<List<ActivityDTO>> GetActivitiesOfCV(int cvId, string activityType)
        {
            var results = new List<ActivityDTO>();
            var properActivities = await _activityRepository.GetList(
                x => x.CVId == cvId
                && x.ActivityType == activityType
            );

            if (properActivities != null)
            {
                foreach (var item in properActivities)
                {
                    var properDescription = await _descriptionRepository.Get(x => x.ActivityId == item.ActId);
                    var activityDTO = _mapper.Map<ActivityDTO>(item);

                    activityDTO.Description = _mapper.Map<TextForm>(properDescription);
                    results.Add(activityDTO);
                }
            }

            return results;
        }

        public async Task<ActivityDTO> AddActivity(ActivityDTO activity)
        {
            var result = await _activityRepository.Add(_mapper.Map<Activity>(activity));

            if (activity.Description != null)
            {
                activity.Description.ActivityId = activity.ActId;
                await _descriptionRepository.Add(_mapper.Map<Description>(activity.Description));
            }

            return _mapper.Map<ActivityDTO>(result);
        }

        public async Task UpdateActivity(ActivityDTO activity)
        {
            var education = _mapper.Map<Activity>(activity);
            var description = _mapper.Map<Description>(activity.Description);
            await _activityRepository.Update(education);
            await _descriptionRepository.Update(description);
        }

        public async Task DeleteActivity(int activityId)
        {
            var properDescription = await _descriptionRepository.Get(x => x.ActivityId == activityId);
            if (properDescription != null)
                await _descriptionRepository.Delete(properDescription);

            var properActivity = await _activityRepository.Get(x => x.ActId == activityId);
            if(properActivity != null)
                await _activityRepository.Delete(properActivity);
        }

        public async Task<List<SkillTypeDTO>> GetSkillTypes(string skillType)
        {
            var skillTypes = await _skillRepository.GetList(x => x.SkillType == skillType);
            var results = new List<SkillTypeDTO>();

            if (skillTypes != null)
                foreach (var item in skillTypes)
                    results.Add(_mapper.Map<SkillTypeDTO>(item));

            return results;
        }

        public async Task<List<SkillDTO>> GetSkillsOfCV(int cvId, string skillType)
        {
            var results = new List<SkillDTO>();
            var properCvSkills = await _cvSkillRepository.GetList(x => x.CVId == cvId);

            if (properCvSkills == null)
                return null;

            foreach (var item in properCvSkills)
            {
                var properSkill = await _skillRepository.Get(
                    x => x.SkillId == item.SkillId
                    && x.SkillType == skillType
                );

                if(properSkill != null)
                {
                    var skill = _mapper.Map<SkillDTO>(properSkill);
                    skill.Level = item.Level;
                    results.Add(skill);
                } 
            }
            return results;
        }

        public async Task<SkillDTO> GetSkill(int skillId, int cvId)
        {
            var properSkill = await _skillRepository.Get(x => x.SkillId == skillId);
            var properCvSkill = await _cvSkillRepository.Get(x => x.CVId == cvId && x.SkillId == skillId);

            if (properSkill == null || properCvSkill == null)
                return null;

            var result = _mapper.Map<SkillDTO>(properSkill);
            result.Level = properCvSkill.Level;

            return result;
        }

        public async Task<SkillDTO> AddSkill(int cvId, SkillDTO skillToAdd)
        {
            var cvSkill = new CVSkill();
            cvSkill.CVId = cvId;
            cvSkill.SkillId = skillToAdd.SkillId;
            cvSkill.Level = skillToAdd.Level;

            await _cvSkillRepository.Add(cvSkill);

            return skillToAdd;
        }

        public async Task UpdateSkill(int cvId, int oldSkillId, SkillDTO skillToUpdate)
        {
            var cvSkill = await _cvSkillRepository.Get(
                    x => x.CVId == cvId
                    && x.SkillId == oldSkillId
                );

            cvSkill.Level = skillToUpdate.Level;

            if (oldSkillId == skillToUpdate.SkillId)
            {
                await _cvSkillRepository.Update(cvSkill);
                return;
            }

            await _cvSkillRepository.Delete(cvSkill);
            cvSkill.SkillId = skillToUpdate.SkillId;
            await _cvSkillRepository.Add(cvSkill);
        }

        public async Task DeleteSkill(int skillId, int cvId)
        {
            var technicalSkill = await _cvSkillRepository.Get(
                x => x.CVId == cvId
                && x.SkillId == skillId
            );

            await _cvSkillRepository.Delete(technicalSkill);
        }
    }
}
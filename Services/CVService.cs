using AutoMapper;
using SimpleCV.Data.DTO.CV;
using SimpleCV.Data.Entities;
using SimpleCV.Data.Repositories.IRepositories;
using SimpleCV.Services.IServices;

namespace SimpleCV.Services
{
    public class CVService : ICVService
    {
        private readonly IMapper _mapper;
        private readonly ICVRepository _cvRepository;

        public CVService(IMapper mapper, ICVRepository cVRepository)
        {
            _mapper = mapper;
            _cvRepository = cVRepository;
        }

        public async Task<CVDTO> AddCV(CVDTO cv)
        {
            return _mapper.Map<CVDTO>(
                await _cvRepository.Add(_mapper.Map<CV>(cv))
            );
        }

        public async Task DeleteCV(int cvId)
        {
            var cvToDelete = await _cvRepository.Get(x => x.CVId == cvId);
            await _cvRepository.Delete(cvToDelete);
        }

        public async Task<List<CVDTO>> GetCVs(int accountId)
        {            
            var properCVs = await _cvRepository.GetList(x => x.AccountId == accountId);
            if(properCVs == null)
                return null;

            var results = new List<CVDTO>();
            foreach(var item in properCVs)
                results.Add(_mapper.Map<CVDTO>(item));
                
            return results;
        }

        public Task<CVDTO> PublishCV(int cvId)
        {
            throw new NotImplementedException();
        }
    }
}
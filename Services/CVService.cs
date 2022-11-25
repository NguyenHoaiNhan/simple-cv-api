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

        public Task<List<CVDTO>> GetCVs(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<CVDTO> GetCV(int cvId)
        {
            return _mapper.Map<CVDTO>(
                await _cvRepository.Get(x => x.CVId == cvId)
            );
        }

        public async Task<CVDTO> AddCV(CVDTO cv)
        {
            var cvToAdd = _mapper.Map<CV>(cv);
            return _mapper.Map<CVDTO>(
                await _cvRepository.Add(cvToAdd)
            );
        }

        public Task<CVDTO> ConfigCV(int cvId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCV(int cvId)
        {
            throw new NotImplementedException();
        }

        public Task<CVDTO> EditView(int cvId)
        {
            throw new NotImplementedException();
        }

        public Task<CVDTO> PublishCV(int cvId)
        {
            throw new NotImplementedException();
        }
    }
}
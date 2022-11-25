using SimpleCV.Data.DTO.CV;

namespace SimpleCV.Services.IServices
{
    public interface ICVService
    {
        Task<List<CVDTO>> GetCVs(int accountId);
        Task<CVDTO> AddCV(CVDTO cv);
        Task DeleteCV(int cvId);
        Task<CVDTO> PublishCV(int cvId);
    }
}
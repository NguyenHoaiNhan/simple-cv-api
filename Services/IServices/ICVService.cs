using SimpleCV.Data.DTO.CV;

namespace SimpleCV.Services.IServices
{
    public interface ICVService
    {
        Task<List<CVDTO>> GetCVs(int userId);
        Task<CVDTO> GetCV(int cvId);
        Task<CVDTO> AddCV(CVDTO cv);
        Task DeleteCV(int cvId);
        Task<CVDTO> EditView(int cvId);
        Task<CVDTO> ConfigCV(int cvId);
        Task<CVDTO> PublishCV(int cvId);
    }
}
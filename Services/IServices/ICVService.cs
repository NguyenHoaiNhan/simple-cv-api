namespace SimpleCV.Services.IServices
{
    public interface ICVService<T>
    {
        Task<T> CreateCV();
        Task<T> UpdateSection();
        Task<T> ConfigCV();
    }
}
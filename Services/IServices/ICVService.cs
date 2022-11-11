namespace SimpleCV.Services.IServices
{
    public interface ICVService<T>
    {
        Task<T> AddCV();
        Task<T> GetCV();
        Task<T> UpdateSection();
        Task<T> DeleteCV();
        Task<T> EditView();
        Task<T> ConfigCV();
        Task<T> PublishCV();
    }
}
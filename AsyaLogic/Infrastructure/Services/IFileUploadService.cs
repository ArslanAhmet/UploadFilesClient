namespace AsyaLogic.Infrastructure.Services
{
    public interface IFileUploadService
    {
        Task<string> UploadFile(IFormFile file);
    }
}

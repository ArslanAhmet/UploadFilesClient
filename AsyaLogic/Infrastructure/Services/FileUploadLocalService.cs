namespace AsyaLogic.Infrastructure.Services
{
    public class FileUploadLocalService : IFileUploadService
    {
        public async Task<string> UploadFile(IFormFile file)
        {
            string path = "";
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string newFileName = Path.Combine(path, DateTime.Now.Ticks.ToString() + Path.GetExtension(file.FileName));
                    using (var fileStream = new FileStream(newFileName, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        return newFileName;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }
    }
}

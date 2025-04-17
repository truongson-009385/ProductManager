using Microsoft.AspNetCore.Http;

namespace ProductManager.Application.Interfaces
{
    public interface IFileUploadService
    {
        Task<string> UploadFileAsync(IFormFile file, string folderName);
        bool DeleteFile(string filePath);
    }
}

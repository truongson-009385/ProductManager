using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ProductManager.Application.Interfaces;

namespace ProductManager.Application.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly string _baseStoragePath;

        public FileUploadService(IConfiguration configuration)
        {
            // Lấy đường dẫn lưu trữ file từ cấu hình trong appsettings.json
            _baseStoragePath = configuration["FileStorage:Path"] ?? "Assets";

            // Đảm bảo thư mục lưu trữ tồn tại
            if (!Directory.Exists(_baseStoragePath))
            {
                Directory.CreateDirectory(_baseStoragePath);
            }
        }

        public async Task<string> UploadFileAsync(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File không hợp lệ", nameof(file));
            }

            // Tạo đường dẫn thư mục để lưu trữ file
            string folderPath = Path.Combine(_baseStoragePath, folderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Tạo tên file duy nhất để tránh trùng lặp
            string uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            string filePath = Path.Combine(folderPath, uniqueFileName);

            // Lưu file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Trả về đường dẫn tương đối để lưu trong DB
            return Path.Combine(folderName, uniqueFileName);
        }

        public bool DeleteFile(string filePath)
        {
            try
            {
                string fullPath = Path.Combine(_baseStoragePath, filePath);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

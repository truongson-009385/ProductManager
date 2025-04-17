using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Application.Interfaces;

namespace ProductManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IFileUploadService _fileUploadService;

        public UploadController(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                if (file == null)
                    return BadRequest("Không có file nào được gửi lên");

                string filePath = await _fileUploadService.UploadFileAsync(file, "documents");

                return Ok(new { filePath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi upload file: {ex.Message}");
            }
        }

        [HttpDelete("delete")]
        public IActionResult DeleteFile(string filePath)
        {
            bool result = _fileUploadService.DeleteFile(filePath);
            if (result)
                return Ok(new { message = "Xóa file thành công" });
            else
                return NotFound("Không tìm thấy file hoặc xóa không thành công");
        }
    }
}

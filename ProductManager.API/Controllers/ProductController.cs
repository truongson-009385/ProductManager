using Microsoft.AspNetCore.Mvc;
using ProductManager.Application.Dtos.Products;
using ProductManager.Application.Interfaces;
using ProductManager.Application.Mappers;

namespace ProductManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IFileUploadService _fileUploadService;
        private string _imagePath = "products";

        public ProductController(
            IProductService productService,
            IFileUploadService fileUploadService
        )
        {
            _productService = productService;
            _fileUploadService = fileUploadService;
        }

        [HttpGet] 
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductRequestDto product, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productModel = product.ToModel();

            if (imageFile != null && imageFile.Length > 0)
            {
                try
                {
                    string imagePath = await _fileUploadService.UploadFileAsync(imageFile, _imagePath);
                    productModel.Image = imagePath;
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Lỗi khi upload hình ảnh: {ex.Message}");
                }
            }

            var newProduct = await _productService.AddAsync(productModel);
            if (newProduct == null) return BadRequest();

            return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateProductRequestDto product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var productModel = product.ToModel(id);
            var updatedProduct = await _productService.UpdateAsync(id, productModel);
            if (updatedProduct == null) return NotFound();
            return Ok(updatedProduct);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return NoContent();
        }
    }
}

using ECommerce.Application.Repositories.ProductRepository;
using ECommerce.Application.ViewModels.Products;
using ECommerce.Domain.Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductsController(IProductReadRepository productReadRepository,IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_productReadRepository.GetAll(tracking:false));
        }      

        [HttpGet("get-by-product-id/{productId}")]
        public async Task<IActionResult> GetByProductIdAsync(string productId)
        {
            return Ok(await _productReadRepository.GetByIdAsync(productId,tracking:false));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(VMCreateProduct vMCreateProduct)
        {
            await _productWriteRepository.AddAsync(
                new()
                {
                    Name = vMCreateProduct.Name,
                    Description = vMCreateProduct.Description,
                    UnitPrice = vMCreateProduct.UnitPrice
                });
            return Ok(await _productWriteRepository.SaveAsync());
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(VMUpdateProduct vMUpdateProduct)
        {
            var product = await _productReadRepository.GetByIdAsync(vMUpdateProduct.Id);
            product.Name = vMUpdateProduct.Name;
            product.UnitPrice = vMUpdateProduct.UnitPrice;
            product.Description = vMUpdateProduct.Description;
            return Ok(await _productWriteRepository.SaveAsync());
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            return Ok(await _productWriteRepository.SaveAsync());
        }
    }
}

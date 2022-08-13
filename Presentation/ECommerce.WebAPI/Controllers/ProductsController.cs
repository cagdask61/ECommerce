using ECommerce.Application.Repositories.ProductRepository;
using ECommerce.Application.ViewModels.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ECommerce.Application.RequestParameters;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] Pagination pagination)
        {
            var products = await _productReadRepository.GetAll(tracking: false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(product => new
            {
                product.Id,
                product.Name,
                product.Description,
                product.UnitPrice,
                product.CreatedDate,
                product.UpdatedDate
            }).ToListAsync();
            return Ok(products);
        }

        [HttpGet("get-by-product-id/{productId}")]
        public async Task<IActionResult> GetByProductIdAsync(string productId)
        {
            return Ok(await _productReadRepository.GetByIdAsync(productId, tracking: false));
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

        [HttpDelete("delete/{productId}")]
        public async Task<IActionResult> Delete(string productId)
        {
            await _productWriteRepository.RemoveAsync(productId);
            return Ok(await _productWriteRepository.SaveAsync());  
        }
    }
}

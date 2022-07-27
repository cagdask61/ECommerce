using ECommerce.Application.Repositories.ProductRepository;
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
            return Ok(_productReadRepository.GetAll());
        }

        [HttpPost("add")]
        public async Task<int> Add(Product product)
        {
            await _productWriteRepository.AddAsync(product);
            return await _productWriteRepository.SaveAsync();
        }

        [HttpGet("get-by-id/{productId}")]
        public async Task<IActionResult> GetByIdAsync(string productId)
        {
            return Ok(await _productReadRepository.GetByIdAsync(productId,tracking:false));
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Service.Services.Products.Dtos;
using Store.Service.Services.Products;

namespace Store.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;


        public ProductsController(IProductService productService)
        {

            _productService = productService;
        }

        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<BraandTypeDetailsDto>>> GetAllBrands()
        => Ok(await _productService.GetAllBrandsAsync());

        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<BraandTypeDetailsDto>>> GetAllTypes()
        => Ok(await _productService.GetAllTypesAsync());


        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAllProducts()
        => Ok(await _productService.GetAllProductsAsync());

        [HttpGet]

        public async Task<ActionResult<ProductDto>> GetProductById(int? id)
        => Ok(await _productService.GetProductBuIdAsync(id));


    }
}

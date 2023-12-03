using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        IProductService _productServices;
        IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productServices = productService;
            _mapper = mapper;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get(string? desc, int? minPrice, int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            IEnumerable<Product> products = await _productServices.GetAllProducts(desc, minPrice, maxPrice, categoryIds);
            IEnumerable<ProductDTO> DTOproducts = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return Ok(DTOproducts);
        }
    }
}

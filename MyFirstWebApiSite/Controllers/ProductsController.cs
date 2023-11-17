﻿using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        IProductService _productServices;
        public ProductsController(IProductService productService)
        {
            _productServices = productService;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get( string? desc, int? minPrice, int? maxPrice, [FromQuery]int?[] categoryIds)
        {
            var products = await _productServices.GetAllProducts(desc,minPrice,maxPrice,categoryIds);
            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")] 
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

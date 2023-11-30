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
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryServices;
        IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryServices = categoryService;
            _mapper = mapper;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Category> categories = await _categoryServices.GetAllCategories();
            IEnumerable<CategoryDTO> DTOcategories = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);
            return Ok(DTOcategories);
        }
    }
}

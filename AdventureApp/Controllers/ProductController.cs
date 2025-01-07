using AdventureApp.Data;
using AdventureApp.Models.ReponseDtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdventureApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper _mapper;

        public ProductController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProducts ()
        {
            var data = dbContext.Products.ToList();

            return Ok(data);
        }

        [HttpGet("base")]
        public async Task<IActionResult> GetAllProductsQueryBase()
        {
            try
            {
                var products = await dbContext.Products.FromSqlRaw("SELECT * FROM Products").ToListAsync();

                var productResponseList = _mapper.Map<List<ProductResponseDto>>(products);

                var response = new ResponseDto
                {
                    Result = productResponseList,
                    StatusCode = 200,
                    IsSuccess = true
                };

                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResponseDto { IsSuccess = false, Message = ex.Message, StatusCode = 500 });
            }
        }

    }
}

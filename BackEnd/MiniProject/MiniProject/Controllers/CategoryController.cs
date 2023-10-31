using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProject.Data;
using MiniProject.Models.Result;
using MiniProject.Models.Request;
using MiniProject.Models;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Principal;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiniProject.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCategoryResult>>> GetCategory()
        {
            var category = await _context.Category
                .OrderBy(x => x.CategoryId)
                .Select(x => new GetCategoryResult()
                {
                    CategoryId = x.CategoryId,
                    NameCategory = x.NameCategory,
                    User = _context.UserTabel.Where(z => z.UserId == x.UserId ).FirstOrDefault(),
                    Name = _context.UserTabel.Where(y => y.UserId == x.UserId).Select(z => z.userName).FirstOrDefault()
               
                })
                .ToListAsync();

            var response = new ApiResponse<IEnumerable<GetCategoryResult>>
            {
                StatusCode = StatusCodes.Status200OK,
                RequestMethod = HttpContext.Request.Method,
                Payload = category
            };

            return Ok(response);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCategoryResult>> Get(int id)
        {
            var categorys = await _context.Category
                .Where(x => x.CategoryId == id)
                .Select(x => new GetCategoryResult()
                {
                    CategoryId = x.CategoryId,
                    NameCategory = x.NameCategory,
                    User = _context.UserTabel.Where(z => z.UserId == x.UserId).FirstOrDefault()
                })
                .FirstOrDefaultAsync();

            if (categorys == null)
            {
                return NotFound("Category Not Found");
            }
            var response = new ApiResponse<GetCategoryResult>
            {
                StatusCode = StatusCodes.Status200OK,
                RequestMethod = HttpContext.Request.Method,
                Payload = categorys
            };
            return Ok(response);
        }
        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryRequest createCategoryRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var checkcategory = _context.Category.Where(x => x.CategoryId == createCategoryRequest.CategoryId).Count();

            if (checkcategory > 0)
            {
                return NotFound("Category Already Exists");
            }
            var checkUser = _context.Category.Where(x => x.UserId == createCategoryRequest.UserId).Count();
            if (checkUser < 0)
            {
                return NotFound("User Not Found");
            }
            var category = new Category
            {
                CategoryId = createCategoryRequest.CategoryId,
                NameCategory = createCategoryRequest.NameCategory,
                UserId = createCategoryRequest.UserId
            };
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCategoryRequest updateCategoryRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _context.Category.FirstOrDefaultAsync(s => s.CategoryId == id);
            if (category == null)
            {
                return NotFound("Category Not Found");
            }

            category.NameCategory = updateCategoryRequest.NameCategory;

            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Category.FirstOrDefaultAsync(s => s.CategoryId == id);
            if (category == null)
            {
                return NotFound("Category Not Found");
            }
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return Ok();
        }
/*
        [HttpGet("getuser")]
        [Authorize] // Hanya pengguna yang sudah login yang dapat mengakses metode ini
        public async Task<ActionResult<IEnumerable<GetUserResult>>> GetUser()
        {
            var userId = User.Identity.Name;
            var category = await _context.Category,
            var users = await _context.UserTabel
                .Where(x => x.UserId == userId) 
                .OrderBy(x => x.CategoryId)
                .Select(x => new GetCategoryResult()
                {
                    CategoryId = x.CategoryId,
                    NameCategory = x.NameCategory,
                    UserId = x.UserId, 
                    UserName = User.Identity.Name 
                })
                .ToListAsync();

            var response = new ApiResponse<IEnumerable<GetCategoryResult>>
            {
                StatusCode = StatusCodes.Status200OK,
                RequestMethod = HttpContext.Request.Method,
                Payload = category
            };
            return Ok(response);
        }
*/
    }
}

using Microsoft.AspNetCore.Mvc;
using MiniProject.Data;
using MiniProject.Models.Request;
using MiniProject.Models.Result;
using MiniProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiniProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var user = await _context.UserTabel.FirstOrDefaultAsync(x => x.useremail == loginRequest.useremail);

                if (user == null)
                {
                    return BadRequest("User not found");
                }

                if (user.userpassword != loginRequest.userpassword)
                {
                    return BadRequest("Invalid password");
                }

                var response = new ApiResponse<string>
                {
                    StatusCode = StatusCodes.Status200OK,
                    RequestMethod = HttpContext.Request.Method,
                    Payload = "Login successful",
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] RegisterRequest registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var checkUser = await _context.UserTabel.FirstOrDefaultAsync(x => x.useremail == registerRequest.useremail);

            if (checkUser != null)
            {
                return BadRequest("User Already Exists");
            }

            User user = new()
            {
                userName = registerRequest.userName,
                useremail = registerRequest.useremail,
                userpassword = registerRequest.userpassword
            };

            _context.UserTabel.Add(user); //add to database
            await _context.SaveChangesAsync(); //save in database

            var response = new ApiResponse<string>
            {
                StatusCode = StatusCodes.Status200OK,
                RequestMethod = HttpContext.Request.Method,
                Payload = "User registered successfully."
            };

            return Ok(response);
        }

        [HttpGet("getuser")]
        public async Task<ActionResult<IEnumerable<GetUserResult>>> GetUser()
        {
            var category = await _context.UserTabel
                .OrderBy(x => x.UserId)
                .Select(x => new GetUserResult()
                {
                    UserId = x.UserId,
                    userName = x.userName
                })
                .ToListAsync();

            var response = new ApiResponse<IEnumerable<GetUserResult>>
            {
                StatusCode = StatusCodes.Status200OK,
                RequestMethod = HttpContext.Request.Method,
                Payload = category
            };

            return Ok(response);
        }

        [HttpGet("getuser{id}")]
        public async Task<ActionResult<GetUserResult>> Get(int id)
        {
            var users = await _context.UserTabel
                .Where(v => v.UserId == id)
                .Select(v => new GetUserResult()
                {
                    UserId = v.UserId,
                    userName = v.userName,
                })
                .FirstOrDefaultAsync();

            if (users == null)
            {
                return NotFound("User Not Found");
            }
            var response = new ApiResponse<GetUserResult>
            {
                StatusCode = StatusCodes.Status200OK,
                RequestMethod = HttpContext.Request.Method,
                Payload = users
            };
            return Ok(response);
        }


    }
}

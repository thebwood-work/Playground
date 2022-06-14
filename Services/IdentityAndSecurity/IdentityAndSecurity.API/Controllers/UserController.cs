using IdentityAndSecurity.Core.Models;
using IdentityAndSecurity.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Playground.Web.Base.Controllers;
using System.Security.Claims;

namespace IdentityAndSecurity.API.Controllers
{
    [Authorize]
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : PlaygroundController<UserController>
    {
        private IUserService _service;

        public UserController(ILogger<UserController> logger, IUserService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet("CurrentUser")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var user = new UserModel();


            if (identity != null)
            {
                var userClaims = identity.Claims;
                if (userClaims.Any())
                {
                    user = new UserModel
                    {
                        UserName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value
                    };
                    var roles = userClaims.Where(x => x.Type == ClaimTypes.Role);
                    

                }
            }
            return Ok(user);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _service.GetAllUsers();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}

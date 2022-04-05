using IdentityAndSecurity.Core.Models;
using IdentityAndSecurity.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Playground.Web.Base.Controllers;

namespace IdentityAndSecurity.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : PlaygroundController<AuthenticationController>
    {
        private IAuthenticationService _service;

        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationService service) : base(logger)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public ActionResult<UserRegisterResponseModel> Register(UserRegisterModel request)
        {
            var response = _service.Register(request);
            if (response != null && response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<UserLoginCredentialsResponseModel> Login(UserLoginCredentialsModel request)
        {
            var response = _service.Login(request);
            if (response != null && response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}

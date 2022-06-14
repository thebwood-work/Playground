using IdentityAndSecurity.Core.Models;
using IdentityAndSecurity.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Playground.Web.Base.Controllers;
using System.Net;

namespace IdentityAndSecurity.API.Controllers
{
    [Authorize]
    [EnableCors("SiteCorsPolicy")]
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
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult<UserRegisterResponseModel> Register(UserRegisterModel request)
        {
            try
            {
                var response = _service.Register(request);
                if (response != null && response.ErrorMessages != null && response.ErrorMessages.Count > 0)
                {
                    return BadRequest(response);
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                this.Logger.LogError("Error happened on Get Addresses", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult<UserLoginCredentialsResponseModel> Login([FromBody]UserLoginCredentialsModel request)
        {
            try
            {
                var response = _service.Login(request);
                if (response != null && response.ErrorMessages != null && response.ErrorMessages.Count > 0)
                {
                    return NotFound(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                this.Logger.LogError("Error happened on Get Addresses", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }
        }

    }
}

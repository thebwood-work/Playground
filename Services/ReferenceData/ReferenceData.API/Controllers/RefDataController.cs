using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Playground.Web.Base.Controllers;
using ReferenceData.Core.Services.Interfaces;
using System.Net;

namespace ReferenceData.API.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class RefDataController : PlaygroundController<RefDataController>
    {
        private readonly IRefDataService _service;
        public RefDataController(ILogger<RefDataController> logger, IRefDataService service) : base(logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("Countries")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetCountries()
        {
            try
            {
                var retVal = _service.GetCountries();

                if (retVal != null)
                {
                    return Ok(retVal);
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                this.Logger.LogError("Error happened on GetCountries", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }
        }

        [HttpGet("States")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetStates()
        {
            try
            {
                var retVal = _service.GetStates();

                if (retVal != null)
                {
                    return Ok(retVal);
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                this.Logger.LogError("Error happened on GetStates", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }
        }
    }
}

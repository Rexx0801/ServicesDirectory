using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NLayerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PremisesController : ControllerBase
    {
        private readonly IPremiseService _premiseService;

        public PremisesController(IPremiseService premiseService)
        {
            _premiseService = premiseService;
        }

        [HttpGet]
        public IActionResult GetPremises([FromQuery] bool includeInactive = false, [FromQuery] string filter = "")
        {
            var premises = _premiseService.GetPremises(includeInactive, filter);
            return Ok(premises);
        }


        [HttpGet("{id}")]
        public IActionResult GetPremiseDetails(Guid id)
        {
            var premise = _premiseService.GetPremiseById(id);
            if (premise == null)
            {
                return NotFound();
            }
            return Ok(premise);
        }

        [HttpPost("{id}/activate")]
        public IActionResult ActivatePremise(Guid id)
        {
            var result = _premiseService.ActivatePremise(id);
            if (!result)
            {
                return BadRequest("Unable to activate premise.");
            }
            return Ok();
        }

        [HttpPost("{id}/deactivate")]
        public IActionResult DeactivatePremise(Guid id)
        {
            var result = _premiseService.DeactivatePremise(id);
            if (!result)
            {
                return BadRequest("Unable to deactivate premise.");
            }
            return Ok();
        }

        [HttpGet("filter")]
        public IActionResult FilterPremises([FromQuery] string filter)
        {
            var premises = _premiseService.FilterPremises(filter);
            return Ok(premises);
        }

        [HttpGet("sort")]
        public IActionResult SortPremises([FromQuery] string columnName)
        {
            var premises = _premiseService.SortPremises(columnName);
            return Ok(premises);
        }

        [HttpGet("new")]
        public IActionResult GetNewPremises()
        {
            var newPremises = _premiseService.GetNewPremises();
            return Ok(newPremises);
        }

        [HttpGet("include-inactive")]
        public IActionResult IncludeInactivePremises()
        {
            var premises = _premiseService.GetAllPremises(includeInactive: true);
            return Ok(premises);
        }

        [HttpPost("{id}/handle-inactive")]
        public IActionResult HandleInactivePremise(Guid id, [FromBody] bool activate)
        {
            if (activate)
            {
                return ActivatePremise(id);
            }
            else
            {
                return DeactivatePremise(id);
            }
        }
    }
}

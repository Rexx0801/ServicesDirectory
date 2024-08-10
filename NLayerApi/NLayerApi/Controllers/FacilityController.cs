using BusinessLayer.Interfaces;
using Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace NLayerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityService _facilityService;

        public FacilityController(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filter, [FromQuery] string? sort)
        {
            try
            {
                var facilities = await _facilityService.GetAllFacilitiesAsync(filter, sort);
                return Ok(facilities);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var facility = await _facilityService.GetFacilityByIdAsync(id);
            if (facility == null) return NotFound();
            return Ok(facility);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FacilityDto facility)
        {
            await _facilityService.AddFacilityAsync(facility);
            return CreatedAtAction(nameof(GetById), new { id = facility.FacilityId }, facility);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, FacilityDto facility)
        {
            if (id != facility.FacilityId) return BadRequest();
            await _facilityService.UpdateFacilityAsync(facility);
            return NoContent();
        }

        [HttpPatch("{id}/mark-inactive")]
        public async Task<IActionResult> MarkAsInactive(Guid id)
        {
            await _facilityService.MarkFacilityAsInactiveAsync(id);
            return NoContent();
        }
    }
}

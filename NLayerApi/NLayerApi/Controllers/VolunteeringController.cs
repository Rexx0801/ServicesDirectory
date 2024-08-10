using BusinessLayer.Interfaces;
using Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace NLayerApi.Controllers
{
    [Route("api/volunteeringopportunity")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        private readonly IVolunteeringService _volunteerService;

        public VolunteerController(IVolunteeringService volunteerService)
        {
            _volunteerService = volunteerService;
        }

        // POST api/volunteer
        [HttpPost]
        public ActionResult<VolunteeringDto> AddVolunteer([FromBody] VolunteeringDto volunteerDto)
        {
            try
            {
                volunteerDto.VolunteeringId = Guid.NewGuid();
                var createdVolunteer = _volunteerService.AddVolunteering(volunteerDto);
                return CreatedAtAction(nameof(GetVolunteer), new { id = createdVolunteer.VolunteeringId }, createdVolunteer);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("Validation", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // GET api/volunteer/{id}
        [HttpGet("{id}")]
        public ActionResult<VolunteeringDto> GetVolunteer(Guid id)
        {
            var volunteer = _volunteerService.Get(id);
            if (volunteer == null)
            {
                return NotFound();
            }
            return Ok(volunteer);
        }

        // GET api/volunteer
        [HttpGet]
        public ActionResult<IEnumerable<VolunteeringDto>> GetVolunteers()
        {
            var volunteers = _volunteerService.Gets();
            return Ok(volunteers);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVolunteer(Guid id, [FromBody] VolunteeringDto volunteerDto)
        {
            if (id != volunteerDto.VolunteeringId)
            {
                return BadRequest(new { message = "ID mismatch between URL and body" });
            }

            var existingVolunteer = _volunteerService.Get(id);
            if (existingVolunteer == null)
            {
                return NotFound(new { message = "Volunteer record not found" });
            }

            if (volunteerDto.VolunteeringContact != null)
                existingVolunteer.VolunteeringContact = volunteerDto.VolunteeringContact;

            if (volunteerDto.VolunteeringPurpose != null)
                existingVolunteer.VolunteeringPurpose = volunteerDto.VolunteeringPurpose;

            if (volunteerDto.VolunteeringOpportunityDetails != null)
                existingVolunteer.VolunteeringOpportunityDetails = volunteerDto.VolunteeringOpportunityDetails;

            if (volunteerDto.StartDate.HasValue)
                existingVolunteer.StartDate = volunteerDto.StartDate;

            if (volunteerDto.EndDate.HasValue)
                existingVolunteer.EndDate = volunteerDto.EndDate;

            if (volunteerDto.VolunteerNos.HasValue)
                existingVolunteer.VolunteerNos = volunteerDto.VolunteerNos;

            if (volunteerDto.IsActive.HasValue)
                existingVolunteer.IsActive = volunteerDto.IsActive;

            if (volunteerDto.PremiseId != Guid.Empty)
                existingVolunteer.PremiseId = volunteerDto.PremiseId;

            _volunteerService.UpdateVolunteering(existingVolunteer);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteVolunteer(Guid id)
        {
            var volunteer = _volunteerService.Get(id);
            if (volunteer == null)
            {
                return NotFound();
            }
            _volunteerService.DeleteVolunteering(id);
            return NoContent();
        }
    }
}

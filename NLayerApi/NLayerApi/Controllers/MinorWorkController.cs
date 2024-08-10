using BusinessLayer.Interfaces;
using Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace NLayerApi.Controllers
{
    [Route("api/minorwork")]
    [ApiController]
    public class MinorWorkController : ControllerBase
    {
        private readonly IMinorWorkService _minorWorkService;

        public MinorWorkController(IMinorWorkService minorWorkService)
        {
            _minorWorkService = minorWorkService;
        }

        [HttpPost]
        public ActionResult<MinorWorkDto> AddMinorWork([FromBody] MinorWorkDto minorWorkDto)
        {
            try
            {
                minorWorkDto.MinorWorkId = Guid.NewGuid();
                var createdMinorWork = _minorWorkService.AddMinorWork(minorWorkDto);
                return CreatedAtAction(nameof(GetMinorWork), new { id = createdMinorWork.MinorWorkId }, createdMinorWork);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("DateValidation", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MinorWorkDto> GetMinorWork(Guid id)
        {
            var minorWork = _minorWorkService.Get(id);
            if (minorWork == null)
            {
                return NotFound();
            }
            return Ok(minorWork);
        }

        [HttpGet]
        public ActionResult<IEnumerable<MinorWorkDto>> GetMinorWorks(string? sortOrder)
        {
            var minorWorks = _minorWorkService.Gets(sortOrder);
            return Ok(minorWorks);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMinorWork(Guid id, [FromBody] MinorWorkDto minorWorkDto)
        {
            if (id != minorWorkDto.MinorWorkId)
            {
                return BadRequest(new { message = "ID mismatch between URL and body" });
            }

            var existingWork = _minorWorkService.Get(id);
            if (existingWork == null)
            {
                return NotFound(new { message = "Minor work not found" });
            }
            if (minorWorkDto.Description != null)
                existingWork.Description = minorWorkDto.Description;

            if (minorWorkDto.IsMinorWorks.HasValue)
                existingWork.IsMinorWorks = minorWorkDto.IsMinorWorks;

            if (minorWorkDto.NotesActions != null)
                existingWork.NotesActions = minorWorkDto.NotesActions;

            if (minorWorkDto.EstimatedCost.HasValue)
                existingWork.EstimatedCost = minorWorkDto.EstimatedCost;

            if (minorWorkDto.ActualCost.HasValue)
                existingWork.ActualCost = minorWorkDto.ActualCost;

            if (minorWorkDto.Directorate != null)
                existingWork.Directorate = minorWorkDto.Directorate;

            if (minorWorkDto.Contact != null)
                existingWork.Contact = minorWorkDto.Contact;

            if (minorWorkDto.AuthorisedByName != null)
                existingWork.AuthorisedByName = minorWorkDto.AuthorisedByName;

            existingWork.Status = minorWorkDto.Status;

            if (minorWorkDto.EnqReceivedDate.HasValue)
                existingWork.EnqReceivedDate = minorWorkDto.EnqReceivedDate;

            if (minorWorkDto.AuthorisedDate.HasValue)
                existingWork.AuthorisedDate = minorWorkDto.AuthorisedDate;

            if (minorWorkDto.ActualStartDate.HasValue)
                existingWork.ActualStartDate = minorWorkDto.ActualStartDate;

            if (minorWorkDto.AnticipatedCompletion.HasValue)
                existingWork.AnticipatedCompletion = minorWorkDto.AnticipatedCompletion;

            if (minorWorkDto.ActualCompletionDate.HasValue)
                existingWork.ActualCompletionDate = minorWorkDto.ActualCompletionDate;

            if (minorWorkDto.IsActive.HasValue)
                existingWork.IsActive = minorWorkDto.IsActive;

            existingWork.PremiseId = minorWorkDto.PremiseId;

            _minorWorkService.UpdateMinorWork(existingWork);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteMinorWork(Guid id)
        {
            var minorWork = _minorWorkService.Get(id);
            if (minorWork == null)
            {
                return NotFound();
            }
            _minorWorkService.DeleteMinorWork(id);
            return NoContent();
        }
    }
}
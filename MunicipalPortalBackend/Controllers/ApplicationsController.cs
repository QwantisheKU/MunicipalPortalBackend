using Microsoft.AspNetCore.Mvc;
using MunicipalPortalBackend.Dtos.ApplicationComplaintDtos;
using MunicipalPortalBackend.Dtos.ApplicationDtos;
using MunicipalPortalBackend.Dtos.ApplicationStatusDtos;
using MunicipalPortalBackend.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using Type = MunicipalPortalBackend.Models.Type;

namespace MunicipalPortalBackend.Controllers
{
	[Route("v1/applications")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
		private readonly IApplicationComplaintService _applicationComplaintService;
        private readonly IApplicationStatusService _applicationStatusService;

		public ApplicationsController(IApplicationService applicationService, IApplicationComplaintService applicationComplaintService, IApplicationStatusService applicationStatusService)
        {
			_applicationService = applicationService;
            _applicationComplaintService = applicationComplaintService;
            _applicationStatusService = applicationStatusService;
        }

		[HttpGet]
		public async Task<ActionResult<List<ApplicationDto>>> GetApplications([Required] Type type)
		{
            //var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var applications = await _applicationService.GetAllAsync(type);

			if (applications == null || !applications.Any())
			{
				return NotFound();
			}

			return Ok(applications);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ApplicationDto>> GetApplication([Required] int id)
        {
            var application = await _applicationService.GetByIdAsync(id);

            if (application == null)
            {
                return NotFound();
            }

            return Ok(application);
        }

       /* [HttpPut("{id}")]
        public async Task<IActionResult> PutApplication(int id, Application application)
        {
            if (id != application.Id)
            {
                return BadRequest();
            }

            _context.Entry(application).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        [HttpPost]
        public async Task<ActionResult<bool>> CreateApplication(CreateApplicationDto createApplicationDto)
        {
            var result = _applicationService.Create(createApplicationDto);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteApplication([Required] int id)
        {
			var result = _applicationService.DeleteById(id);

			if (result)
			{
				return Ok(result);
			}

			return BadRequest();
		}

		[HttpGet("{applicationId}/complaints")]
		public async Task<ActionResult<ApplicationComplaintDto>> GetApplicationComplaints(int applicationId)
		{
			var applicationComplaints = await _applicationComplaintService.GetAllByApplicationIdAsync(applicationId);

			if (applicationComplaints == null || !applicationComplaints.Any())
			{
				return Ok(applicationComplaints);
			}

			return BadRequest();
		}

		// TODO: ApplicationId in ApplicationComplaintDto
		[HttpPost("{applicationId}/complaints")]
		public async Task<ActionResult<bool>> CreateApplicationComplaint(int applicationId, [FromBody] ApplicationComplaintDto applicationComplaintDto)
        {
            var result = _applicationComplaintService.Create(applicationId, applicationComplaintDto);

			if (result)
			{
				return Ok(result);
			}

			return BadRequest();
		}

		[HttpPost("{applicationId}/statuses")]
		public async Task<ActionResult<bool>> CreateApplicationStatus(int applicationId, [FromBody] CreateApplicationStatusDto createApplicationStatusDto)
		{
            createApplicationStatusDto.ApplicationId = applicationId;
			var result = _applicationStatusService.Create(createApplicationStatusDto);

			if (result)
			{
				return Ok(result);
			}

			return BadRequest();
		}
	}
}

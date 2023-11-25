using AutoMapper;
using MunicipalPortalBackend.Dtos.ApplicationDtos;
using MunicipalPortalBackend.Dtos.ApplicationStatusDtos;
using MunicipalPortalBackend.Models;
using MunicipalPortalBackend.Repositories;
using MunicipalPortalBackend.Repositories.Interfaces;
using MunicipalPortalBackend.Services.Interfaces;
using Type = MunicipalPortalBackend.Models.Type;

namespace MunicipalPortalBackend.Services
{
	public class ApplicationService : IApplicationService
	{
		private readonly IApplicationRepository _applicationRepository;
		//private readonly IMunicipalDepartmentService _municipalDepartmentService;
		private readonly IApplicationStatusService _applicationStatusService;
		private readonly IMapper _mapper;

		public ApplicationService(IApplicationRepository applicationRepository, IApplicationStatusService applicationStatusService, IMapper mapper)
		{
			_applicationRepository = applicationRepository;
			_applicationStatusService = applicationStatusService;
			_mapper = mapper;
		}

		public bool Create(CreateApplicationDto createApplicationDto)
		{
			var application = _mapper.Map<Application>(createApplicationDto);

			if (application == null)
			{
				return false;
			}

			try
			{
				// Create application
				_applicationRepository.Create(application);
				_applicationRepository.Save();

				// Create first application status == ToDo
				var applicationStatus = new ApplicationStatus();
				applicationStatus.Status = application.Status;
				applicationStatus.ApplicationId = application.Id;
				var mappedApplicationStatus = _mapper.Map<CreateApplicationStatusDto>(applicationStatus);
				_applicationStatusService.Create(mappedApplicationStatus);

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		// Changes status to Closed
		public bool DeleteById(int id)
		{
			try
			{
				_applicationRepository.DeleteById(id);
				_applicationRepository.Save();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public async Task<List<ApplicationDto>> GetAllAsync(Type type)
		{
			var applications = type switch
			{
				Type.All => await _applicationRepository.GetAllAsync(),
				Type.User => throw new NotImplementedException(),
				Type.Department => throw new NotImplementedException(),
				_ => new List<Application>()
			};
			//var applications = await _applicationRepository.GetAllAsync();

			var mappedApplications = _mapper.Map<List<ApplicationDto>>(applications);

			return mappedApplications;
		}

		public async Task<ApplicationDto> GetByIdAsync(int id)
		{
			var application = await _applicationRepository.GetByIdAsync(id);

			var mappedApplication = _mapper.Map<ApplicationDto>(application);

			return mappedApplication;
		}
	}
}

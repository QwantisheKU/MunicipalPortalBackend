using AutoMapper;
using MunicipalPortalBackend.Dtos.ApplicationStatusDtos;
using MunicipalPortalBackend.Models;
using MunicipalPortalBackend.Repositories.Interfaces;
using MunicipalPortalBackend.Services.Interfaces;

namespace MunicipalPortalBackend.Services
{
	public class ApplicationStatusService : IApplicationStatusService
	{
		private readonly IApplicationStatusRepository _applicationStatusRepository;
		private readonly IMapper _mapper;

		public ApplicationStatusService(IApplicationStatusRepository applicationStatusRepository, IMapper mapper)
		{
			_applicationStatusRepository = applicationStatusRepository;
			_mapper = mapper;
		}

		public bool Create(CreateApplicationStatusDto createApplicationStatusDto)
		{
			var applicationStatus = _mapper.Map<ApplicationStatus>(createApplicationStatusDto);

			if (applicationStatus == null)
			{
				return false;
			}

			try
			{
				_applicationStatusRepository.Create(applicationStatus);
				_applicationStatusRepository.Save();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public async Task<List<ApplicationStatusDto>> GetAllByApplicationIdAsync(int applicationId)
		{
			var applicationsStatuses = await _applicationStatusRepository.GetAllByApplicationIdAsync(applicationId);

			var mappedApplicationStatuses = _mapper.Map<List<ApplicationStatusDto>>(applicationsStatuses);

			return mappedApplicationStatuses;
		}
	}
}

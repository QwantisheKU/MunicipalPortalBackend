using AutoMapper;
using MunicipalPortalBackend.Dtos.ApplicationComplaintDtos;
using MunicipalPortalBackend.Dtos.ApplicationDtos;
using MunicipalPortalBackend.Models;
using MunicipalPortalBackend.Repositories;
using MunicipalPortalBackend.Repositories.Interfaces;
using MunicipalPortalBackend.Services.Interfaces;
using System.Security.Claims;

namespace MunicipalPortalBackend.Services
{
	public class ApplicationComplaintService : IApplicationComplaintService
	{
		private readonly IApplicationComplaintRepository _applicationComplaintRepository;
		private readonly IMapper _mapper;

		public ApplicationComplaintService(IApplicationComplaintRepository applicationComplaintRepository, IMapper mapper)
		{
			_applicationComplaintRepository = applicationComplaintRepository;
			_mapper = mapper;
		}

		public bool Create(int applicationId, ApplicationComplaintDto applicationComplaintDto)
		{
			var applicationComplaint = _mapper.Map<ApplicationComplaint>(applicationComplaintDto);
			applicationComplaint.ApplicationId = applicationId;

			if (applicationComplaint == null)
			{
				return false;
			}

			try
			{
				_applicationComplaintRepository.Create(applicationComplaint);
				_applicationComplaintRepository.Save();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public async Task<List<ApplicationComplaintDto>> GetAllByApplicationIdAsync(int applicationId)
		{
			var applicationComplaints = await _applicationComplaintRepository.GetAllByApplicationIdAsync(applicationId);

			var mappedApplications = _mapper.Map<List<ApplicationComplaintDto>>(applicationComplaints);

			return mappedApplications;
		}

		public async Task<ApplicationComplaintDto> GetByIdAsync(int id)
		{
			var applicationComplaint = await _applicationComplaintRepository.GetByIdAsync(id);

			var mappedApplication = _mapper.Map<ApplicationComplaintDto>(applicationComplaint);

			return mappedApplication;
		}
	}
}

using AutoMapper;
using MunicipalPortalBackend.Dtos.MunicipalDepartmentDtos;
using MunicipalPortalBackend.Repositories.Interfaces;
using MunicipalPortalBackend.Services.Interfaces;

namespace MunicipalPortalBackend.Services
{
	public class MunicipalDepartmentService : IMunicipalDepartmentService
	{
		private readonly IMunicipalDepartmentRepository _municipalDepartmentRepository;
		private readonly IMapper _mapper;

		public MunicipalDepartmentService(IMunicipalDepartmentRepository municipalDepartmentRepository, IMapper mapper)
		{
			_municipalDepartmentRepository = municipalDepartmentRepository;
			_mapper = mapper;
		}

		public async Task<List<MunicipalDepartmentDto>> GetAllAsync()
		{
			var municipalDepartments = await _municipalDepartmentRepository.GetAllAsync();

			var mappedMunicipalDepartments = _mapper.Map<List<MunicipalDepartmentDto>>(municipalDepartments);

			return mappedMunicipalDepartments;
		}
	}
}

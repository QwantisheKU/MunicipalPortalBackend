using AutoMapper;
using MunicipalPortalBackend.Dtos.ApplicationComplaintDtos;
using MunicipalPortalBackend.Dtos.ApplicationDtos;
using MunicipalPortalBackend.Dtos.ApplicationStatusDtos;
using MunicipalPortalBackend.Dtos.AuthDtos;
using MunicipalPortalBackend.Dtos.CategoryDtos;
using MunicipalPortalBackend.Dtos.MunicipalDepartmentDtos;
using MunicipalPortalBackend.Dtos.NewsDtos;
using MunicipalPortalBackend.Models;

namespace MunicipalPortalBackend.Mapper
{
	public class EntityMapper : Profile
	{
		public EntityMapper()
		{
			// Application
			CreateMap<Application, ApplicationDto>().ReverseMap();
			CreateMap<Application, CreateApplicationDto>().ReverseMap();

			// ApplicationComplaint
			CreateMap<ApplicationComplaint, ApplicationComplaintDto>().ReverseMap();

			// Category
			CreateMap<Category, CategoryDto>().ReverseMap();

			// MunicipalDepartment
			CreateMap<MunicipalDepartment, MunicipalDepartmentDto>().ReverseMap();

			// User
			CreateMap<User, RegisterUserDto>().ReverseMap();
			CreateMap<User, LoginUserDto>().ReverseMap();

			// ApplicationStatus
			CreateMap<ApplicationStatus, ApplicationStatusDto>().ReverseMap();
			CreateMap<ApplicationStatus, CreateApplicationStatusDto>().ReverseMap();

			// News
			CreateMap<News, NewsDto>().ReverseMap();
			CreateMap<News, CreateNewsDto>().ReverseMap();
		}
	}
}

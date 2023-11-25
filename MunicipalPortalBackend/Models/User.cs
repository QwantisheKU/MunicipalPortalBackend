using Microsoft.AspNetCore.Identity;

namespace MunicipalPortalBackend.Models
{
	public class User : IdentityUser
	{
		public int? MunicipalDepartmentId { get; set; }
		
		public MunicipalDepartment? MunicipalDepartment { get; set; }
	}
}

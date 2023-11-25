using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MunicipalPortalBackend.Models;

namespace MunicipalPortalBackend.Data
{
	public class MunicipalPortalBackendContext : IdentityDbContext<User>
    {
        public MunicipalPortalBackendContext (DbContextOptions<MunicipalPortalBackendContext> options)
            : base(options)
        {
        }

        public DbSet<Application> Application { get; set; } = default!;

		public DbSet<ApplicationComplaint> ApplicationComplaint { get; set; } = default!;

		public DbSet<Category> Category { get; set; } = default!;

		public DbSet<MunicipalDepartment> MunicipalDepartment { get; set; } = default!;

		public DbSet<ApplicationStatus> ApplicationStatus { get; set; } = default!;

		public DbSet<News> News { get; set; } = default!;
	}
}

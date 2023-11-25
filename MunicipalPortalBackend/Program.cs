using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MunicipalPortalBackend.Data;
using MunicipalPortalBackend.Models;
using MunicipalPortalBackend.Repositories;
using MunicipalPortalBackend.Repositories.Interfaces;
using MunicipalPortalBackend.Services;
using MunicipalPortalBackend.Services.Interfaces;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
if (builder.Environment.IsDevelopment())
{
	builder.Services.AddDbContext<MunicipalPortalBackendContext>(options =>
	options.UseNpgsql(builder.Configuration["ConnectionStrings:MunicipalPortalBackendContext"] ?? throw new InvalidOperationException("Connection string 'MunicipalPortalBackendContext' not found.")));
}
else if (builder.Environment.IsProduction())
{
	builder.Services.AddDbContext<MunicipalPortalBackendContext>(options =>
	options.UseNpgsql(builder.Configuration["ConnectionStrings:AzureDbContext"] ?? throw new InvalidOperationException("Connection string 'AzureDbContext' not found.")));
}

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
	options.Password = new PasswordOptions
	{
		RequireDigit = false,
		RequiredLength = 6,
		RequireNonAlphanumeric = false,
		RequireUppercase = false
	};
	options.User.RequireUniqueEmail = true;
})
	.AddEntityFrameworkStores<MunicipalPortalBackendContext>()
	.AddDefaultTokenProviders();

builder.Services.AddAuthentication(auth =>
{
	auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		RequireExpirationTime = true,
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AuthSettings:Token"])),
		ValidateIssuer = false,
		ValidateAudience = false
	};
});

// Register Repositories
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IApplicationRepository, ApplicationRepository>();
builder.Services.AddTransient<IApplicationComplaintRepository, ApplicationComplaintRepository>();
builder.Services.AddTransient<IMunicipalDepartmentRepository, MunicipalDepartmentRepository>();
builder.Services.AddTransient<IApplicationStatusRepository, ApplicationStatusRepository>();
builder.Services.AddTransient<INewsRepository, NewsRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

// Register Services
builder.Services.AddTransient<IApplicationService, ApplicationService>();
builder.Services.AddTransient<IApplicationComplaintService, ApplicationComplaintService>();
builder.Services.AddTransient<IMunicipalDepartmentService, MunicipalDepartmentService>();
builder.Services.AddTransient<IApplicationStatusService, ApplicationStatusService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<INewsService, NewsService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ILocationService, LocationService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddHttpClient();

builder.Services
	.AddControllers()
	.AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/*if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}*/
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

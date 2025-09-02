using Microsoft.EntityFrameworkCore;
using RecruitmentPortal.API.Middlewares;
using RecruitmentPortal.Repository.Implementation;
using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Service.Helpers;
using RecruitmentPortal.Service.Implementation;
using RecruitmentPortal.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RecruitmentPortalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure CORS policy to allow requests from the client application
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAllOrigin",
        builder =>
        {
            builder
                .AllowAnyOrigin() // Allow all Origins
                .AllowAnyHeader() // Allow all headers (like Content-Type)
                .AllowAnyMethod(); // Allow all HTTP methods (GET, POST, etc.)
        }
    );
});

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ISharedService, SharedService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IJobService, JobService>();

builder.Services.AddScoped<JwtTokenHelper>();

// generic repository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<ICompanyLocationRepository, CompanyLocationRepository>();
builder.Services.AddScoped<ICompanySocialMediumRepository, CompanySocialMediumRepository>();
builder.Services.AddScoped<ICompanyStatusRepository, CompanyStatusRepository>();
builder.Services.AddScoped<IDegreeRepository, DegreeRepository>();
builder.Services.AddScoped<IJobRoleRepository, JobRoleRepository>();
builder.Services.AddScoped<IJobTypeRepository, JobTypeRepository>();
builder.Services.AddScoped<IJobCategoryRepository, JobCategoryRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();

var app = builder.Build();

app.UseStaticFiles(); 

// allowing all origin
app.UseCors("AllowAllOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<JwtMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

using Microsoft.EntityFrameworkCore;
using RecruitmentPortal.Repository.Implementation;
using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Repository.Models;
using RecruitmentPortal.Service.Implementation;
using RecruitmentPortal.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
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

// generic repository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();

var app = builder.Build();

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

app.MapControllers();
app.Run();

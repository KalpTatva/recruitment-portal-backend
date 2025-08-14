using RecruitmentPortal.Repository.Implementation;
using RecruitmentPortal.Repository.Interfaces;
using RecruitmentPortal.Service.Implementation;
using RecruitmentPortal.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

using Education.Application.Cursos;
using Education.Persistence;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EducationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
 );

builder.Services.AddMediatR(typeof(GetCursoByIdQueryHandler).Assembly);

builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssemblyContaining<CreateCursoCommandRequest>();
});

builder.Services.AddAutoMapper(typeof(GetCursoByIdQueryHandler).Assembly);

builder.Services.AddCors(x => x.AddPolicy("corsApp", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();
app.UseCors("corsApp");
// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();

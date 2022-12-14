using Application.Infrastructure;
using Application.Service;
using Domain.Infrastructure;
using Domain.Models;
using Domain.Service;
using Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(MapperService).Assembly);
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddScoped<IBaseRepository<BaseEntity>, BaseRepository<BaseEntity>>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

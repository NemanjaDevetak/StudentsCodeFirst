using Domain.Models;
using Infrastructure.Domain;

UnitOfWork uof = new();

Course c = new();
c.CreatedAt = DateTime.Now;
c.Code = "12345";
c.CourseName = "Software architecture";

uof.CourseRepository.Insert(c);
uof.Save();
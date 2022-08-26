using Application.Infrastructure;
using Application.Service;
using Application.Service.Dtos;
using Domain.Models;
using Infrastructure.Domain;

ICourseService courseService = new CourseService();

UpdateCourseDto course = new();
course.Id = 3;
course.Code = "321";
course.CourseName = "Test";

await courseService.UpdateCourse(course);
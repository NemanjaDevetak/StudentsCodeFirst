using Domain.Models;
using Infrastructure.Domain;

UnitOfWork uof = new();

var s = uof.StudentRepository.GetById(1);
var p = uof.ProfessorRepository.GetById(1);
var c = uof.CourseRepository.GetById(1);

uof.CourseRepository.AddProfessor(c, p);
uof.CourseRepository.AddStudent(c, s);

uof.Save();
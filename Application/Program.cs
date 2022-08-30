using Application.Infrastructure;
using Application.Service;
using Application.Service.Dtos;
using AutoMapper;
using Domain.Models;
using Infrastructure.Domain;
using System.Collections.Generic;

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MapperService());
});



IMapper mapper = config.CreateMapper();

IStudentService studentService = new StudentService(mapper);

UpdateStudentDto updateStudentDto = new UpdateStudentDto()
{
    Id = 3,
    FirstName = "Ana",
    LastName = "Anic",
    Address = new AddressDto { Country = "Srbija", City = "Pancevo", ZipCode = "26000", Street = "Ulica 13" }
};

await studentService.UpdateStudent(updateStudentDto);
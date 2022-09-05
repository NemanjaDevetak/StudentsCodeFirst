using AutoMapper;
using Domain.Infrastructure;
using Domain.Models;
using Domain.Service;
using Infrastructure.Domain;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApiTest
{
    public class UnitOfWorkFixture : IDisposable
    {
        public UnitOfWorkFixture()
        {
            context = new DatabaseFixture().context;
            Instance = new UnitOfWork(
            context,
            new BaseRepository<BaseEntity>(context),
            new CourseRepository(context),
            new DepartmentRepository(context),
            new ProfessorRepository(context),
            new StudentRepository(context));
        }

        public void Dispose()
        {
            context.Dispose();
        }
        public IUnitOfWork Instance { get; }
        public ApplicationDbContext context { get; private set; }
        public UnitOfWork unitOfWork { get; private set; }
    }
}

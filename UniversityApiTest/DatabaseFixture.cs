using Application.Infrastructure;
using Application.Service;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApiTest
{
    public class DatabaseFixture : IDisposable
    {
        public ApplicationDbContext context;

        public DatabaseFixture()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase(databaseName: "UniversityDbInMemory");

            var dbContextOptions = builder.Options;
            context = new ApplicationDbContext(dbContextOptions);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}

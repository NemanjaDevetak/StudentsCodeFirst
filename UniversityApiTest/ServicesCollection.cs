using Application.Infrastructure;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApiTest
{
    [CollectionDefinition("Services collection")]
    public class ServicesCollection : ICollectionFixture<ServicesCollection>
    {
        public ServicesCollection()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperService()));
            mapper = configuration.CreateMapper();
        }
        public IMapper mapper { get; }
    }
}

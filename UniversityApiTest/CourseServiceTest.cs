using Application.Infrastructure;
using Application.Service;
using Application.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApiTest
{
    [Collection("Services collection")]
    public class CourseServiceTest : IClassFixture<UnitOfWorkFixture>
    {
        UnitOfWorkFixture unitOfWorkFixture;
        ServicesCollection servicesCollection;

        public CourseServiceTest(UnitOfWorkFixture unitOfWorkFixture, ServicesCollection servicesCollection)
        {
            this.unitOfWorkFixture = unitOfWorkFixture;
            this.servicesCollection = servicesCollection;
        }

        [Fact]
        public async Task Add_SingleCourse_ReturnsNumberOFCourses() {
            var courseService = new CourseService(unitOfWorkFixture.context, servicesCollection.mapper, unitOfWorkFixture.unitOfWork);
            InsertCourseDto course = new InsertCourseDto();

            course.Code = "st1";
            course.CourseName = "Software testing";

            await courseService.AddCourse(course);

            Assert.Equal(1, unitOfWorkFixture.context.Courses.Count());
        }
    }
}

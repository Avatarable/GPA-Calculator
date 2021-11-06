using APPDataAccess.Repositories.InMemoryRepository.Interfaces;
using APPModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace APPDataAccess.Repositories.InMemoryRepository.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        public bool Add<T>(T model)
        {
            Course course = model as Course;
            InMemoryStore.Courses.Add(course);

            return true;
        }

        public List<Course> GetCourses()
        {
            return InMemoryStore.Courses;
        }
    }
}

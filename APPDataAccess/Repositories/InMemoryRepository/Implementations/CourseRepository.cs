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
            int rowCountBefore = this.RowCount();

            Course course = model as Course;
            if (!InMemoryStore.Courses.Exists(n => n.CourseNameAndCode.ToLower() == course.CourseNameAndCode.ToLower()))
            {
                InMemoryStore.Courses.Add(course);
            }

            int rowCountAfter = this.RowCount();
            if(rowCountBefore >= rowCountAfter)
            {
                return false;
            }
            return true;
        }

        public List<Course> GetCourses()
        {
            return InMemoryStore.Courses;
        }

        public bool Reset()
        {
            InMemoryStore.Courses.Clear();
            if (this.RowCount() == 0)
            {
                return true;
            }
            return false;
        }

        public int RowCount()
        {
            return InMemoryStore.Courses.Count;
        }
    }
}

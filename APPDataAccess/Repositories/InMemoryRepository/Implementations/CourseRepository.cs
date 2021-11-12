using APPDataAccess.Repositories.InMemoryRepository.Interfaces;
using APPModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APPDataAccess.Repositories.InMemoryRepository.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        public Task<bool> AddAsync<T>(T model)
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
                return Task.Run(()=>false);
            }
            return Task.Run(() => true);
        }

        public Task<List<Course>> GetCoursesAsync()
        {
            return Task.Run(() => InMemoryStore.Courses);
        }

        public Task<bool> ResetAsync()
        {
            InMemoryStore.Courses.Clear();
            if (this.RowCount() == 0)
            {
                return Task.Run(() => true);
            }
            return Task.Run(() => false);
        }

        public int RowCount()
        {
            return InMemoryStore.Courses.Count;
        }
    }
}

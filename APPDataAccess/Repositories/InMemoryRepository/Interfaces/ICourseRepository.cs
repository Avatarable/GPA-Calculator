using APPModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace APPDataAccess.Repositories.InMemoryRepository.Interfaces
{
    public interface ICourseRepository : ICRUDRepository
    {
        public List<Course> GetCourses();
    }
}

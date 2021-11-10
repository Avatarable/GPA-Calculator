using APPModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace APPDataAccess.Repositories.InFileRepository.Interfaces
{
    public interface ICourseFileRepository : ICRUDRepository
    {
        
        public List<Course> LoadCourses();
    }
}

using APPModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace APPDataAccess.Repositories.InMemoryRepository.Interfaces
{
    public interface ICourseRepository : ICRUDRepository
    {
        public Task<List<Course>> GetCoursesAsync();
        
    }
}

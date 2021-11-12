using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APPDataAccess.Repositories
{
    public interface ICRUDRepository
    {
        Task<bool> AddAsync<T>(T model);
        Task<bool> ResetAsync();
        int RowCount();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace APPDataAccess.Repositories
{
    public interface ICRUDRepository
    {
        bool Add<T>(T model);
        //int RowCount();
    }
}

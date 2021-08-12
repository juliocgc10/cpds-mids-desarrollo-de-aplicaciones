using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFReg.DataAccess
{
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}

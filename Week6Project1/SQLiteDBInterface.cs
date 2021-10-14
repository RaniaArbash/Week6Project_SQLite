using System;
using SQLite;

namespace Week6Project1
{
    public interface SQLiteDBInterface
    {
        SQLiteAsyncConnection createSQLiteDB();
    }
}

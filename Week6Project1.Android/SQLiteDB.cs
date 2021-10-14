using System;
using System.IO;
using System.Runtime.CompilerServices;
using SQLite;
using Xamarin.Forms;
using Week6Project1.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(Week6Project1.Droid.SQLiteDB))]
namespace Week6Project1.Droid
{
    public class SQLiteDB : SQLiteDBInterface
    {
        public SQLiteAsyncConnection createSQLiteDB()
        {
            var doucment_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(doucment_path, "todoDB.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}

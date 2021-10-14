using System;
using System.IO;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using SQLite;
using Week6Project1.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(Week6Project1.iOS.SQLiteDB))]
namespace Week6Project1.iOS
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

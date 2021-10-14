using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace Week6Project1
{
    public class DatabaseManger
    {
        SQLiteAsyncConnection _connection;

        public DatabaseManger()
        {
           _connection = DependencyService.Get<SQLiteDBInterface>().createSQLiteDB();
        }


        public async Task<ObservableCollection<toDoTask>> CreateTabel()
        {
            // create new table in it not exist
           await  _connection.CreateTableAsync<toDoTask>();
            // select * from ToDoTask
           var todosFromDB = await _connection.Table<toDoTask>().ToListAsync();
            var allTodos = new ObservableCollection<toDoTask>(todosFromDB);
            return allTodos;
        }

        public async void InsertNewTodo(toDoTask newTask)
        {
            // insert into ToDoTask values ()
            await _connection.InsertAsync(newTask);
        }

        public async void updateToDo(toDoTask toUpdate)
        {
            // update where id == id 
            await _connection.UpdateAsync(toUpdate);
        }


        public async void deleteToDo(toDoTask toDelete)
        {
            // update where id == id 
            await _connection.DeleteAsync(toDelete);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6Project1.SQLite_ToDoApp;
using Xamarin.Forms;

namespace Week6Project1
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<toDoTask> allTasks = new ObservableCollection<toDoTask>();
        TaskManager dbModel = new TaskManager();
        DatabaseManger dbManger = new DatabaseManger();

        public MainPage()
        {
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {

            allTasks = await dbManger.CreateTabel();
            allTasksTable.ItemsSource = allTasks;
            base.OnAppearing();

        }

        public async void addNewTask(object sender, EventArgs e)
        {
            toDoTask newTask = await TaskManager.InputBox(this.Navigation, null);
            dbManger.InsertNewTodo(newTask);
            allTasks.Add(newTask);
            allTasksTable.ItemsSource = null;
            allTasksTable.ItemsSource = allTasks;



        }

        public  void deleteFromDB(object sender, EventArgs e)
        {
            // MenuItem item = (e as MenuItem);
             toDoTask t = (sender as MenuItem).CommandParameter as toDoTask;

            dbManger.deleteToDo(t);

            allTasksTable.ItemsSource = null;
            allTasksTable.ItemsSource = allTasks;


        }

        public async void updateDB(object sender, EventArgs e)
        {
            
            toDoTask toupdateTask = await TaskManager.InputBox(this.Navigation, allTasksTable.SelectedItem as toDoTask);
            dbManger.updateToDo(toupdateTask);
            allTasksTable.ItemsSource = null;
            allTasksTable.ItemsSource = allTasks;
        }
    }

}

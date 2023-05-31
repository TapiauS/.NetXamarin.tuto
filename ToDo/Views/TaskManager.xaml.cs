using System;
using ToDo.Models;
using Xamarin.Forms;

namespace ToDo.Views
{
    [QueryProperty(nameof(TaskId), nameof(TaskId))]
    public partial class TaskManager : ContentPage
    {

        public string TaskId { set
            {
                LoadTask(value);
            } }

        public TaskManager()
        {
            InitializeComponent();
            BindingContext = new ToDoTask();
        }

        async void LoadTask(string taskId)
        {
            try
            {
                int id = Convert.ToInt32(taskId);
                BindingContext = await App.Database.GetToDoTask(id);
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        async void SaveButtonClicked(object sender, EventArgs e)
        {
            ToDoTask task = (ToDoTask)BindingContext;
            task.Validate = validated.IsChecked;
            await App.Database.SaveTask(task);
        }

        async void DeleteTaskClicked(object sender, EventArgs e)
        {
            ToDoTask task = (ToDoTask)BindingContext;
            await App.Database.DeleteTodoTask(task);
            await Shell.Current.GoToAsync("..");
        }

    }
}
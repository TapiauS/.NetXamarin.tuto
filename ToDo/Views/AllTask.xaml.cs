
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllTask : ContentPage
    {
        public AllTask()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Console.WriteLine("I go here");
            allTaskCollection.ItemsSource=await App.Database.GetToDoTasks();

        }
        async void AddTaskClicked(object sender,EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(TaskManager)}");
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                ToDoTask task = (ToDoTask)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(TaskManager)}?{nameof(TaskManager.TaskId)}={task.Id}");
            }
        }
    }
}
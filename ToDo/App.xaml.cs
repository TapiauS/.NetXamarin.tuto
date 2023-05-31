using System;
using System.IO;
using ToDo.Data;
using ToDo.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo
{
    public partial class App : Application
    {
        private static ToDoTaskDatabase database;
        public static ToDoTaskDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ToDoTaskDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NoteReloaded.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

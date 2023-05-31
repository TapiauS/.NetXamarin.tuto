using System;
using System.Collections.Generic;

using ToDo.Views;
using Xamarin.Forms;

namespace ToDo
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AllTask), typeof(AllTask));
            Routing.RegisterRoute(nameof(TaskManager), typeof(TaskManager));
        }
    }
}

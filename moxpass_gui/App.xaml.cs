using moxpass_gui.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace moxpass_gui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void AppStart(object sender, StartupEventArgs e)
        {
            Prompt p = new Prompt();
            p.Show();
        }
    }

    
}

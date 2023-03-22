using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace moxpass_gui.Views
{
    /// <summary>
    /// Interaction logic for Warning_PasswordInconsistent.xaml
    /// </summary>
    public partial class Warning_PasswordInconsistent : Window
    {
        public Warning_PasswordInconsistent()
        {
            InitializeComponent();
        }

        public void Button_Clicked(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

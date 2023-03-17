using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for RegisterNewUser.xaml
    /// </summary>
    public partial class RegisterNewUser : Window
    {
        public string Email
        {
            get { return (string)GetValue(EmailProperty); }
            set { SetValue(EmailProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Email.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EmailProperty =
            DependencyProperty.Register("Email", typeof(string), typeof(RegisterNewUser), new PropertyMetadata(string.Empty));
        public bool CanCreate
        {
            get { return (bool)GetValue(CanCreateProperty); }
            set { SetValue(CanCreateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanCreate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanCreateProperty =
            DependencyProperty.Register("CanCreate", typeof(bool), typeof(RegisterNewUser), new PropertyMetadata(false));

        public RegisterNewUser()
        {
            InitializeComponent();
        }

        public void BackClicked(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Show();
            Close();
        }
        public void CreateClicked(object sender, RoutedEventArgs e)
        {
            Debug.Print($"Current Email is: {Email}");
        }
    }
}

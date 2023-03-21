using moxpass_gui.Models;
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
    /// Interaction logic for Prompt.xaml
    /// </summary>
    public partial class Prompt : Window
    {
        public string Email
        {
            get { return (string)GetValue(EmailProperty); }
            set { SetValue(EmailProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Email.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EmailProperty =
            DependencyProperty.Register("Email", typeof(string), typeof(Prompt), new PropertyMetadata(string.Empty));



        public bool PasswordBoxReady
        {
            get { return (bool)GetValue(PasswordBoxReadyProperty); }
            set { SetValue(PasswordBoxReadyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PasswordBoxReady.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordBoxReadyProperty =
            DependencyProperty.Register("PasswordBoxReady", typeof(bool), typeof(Prompt), new PropertyMetadata(false));



        public Prompt()
        {
            InitializeComponent();
            InitializeUiText();
            PassBoxTitle.PasswordChanged += PassBoxTitle_PasswordChanged;
        }

        private void PassBoxTitle_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(PassBoxTitle.SecurePassword.Length > 4)
            {
                PasswordBoxReady = true;
            } 
            else 
            { 
                PasswordBoxReady = false; 
            }
        }

        public void CancelClicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void LoginClicked(object sender, RoutedEventArgs e)
        {
            Debug.Print("The email is:");
            Debug.Print(Email);
        }

        public void RegisterClicked(object sender, RoutedEventArgs e)
        {
            var register = new RegisterNewUser();
            register.Show();
            this.Hide();
        }



        public UiTextResource UiTexts
        {
            get { return (UiTextResource)GetValue(UiTextsProperty); }
            set { SetValue(UiTextsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UiTexts.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UiTextsProperty =
            DependencyProperty.Register("UiTexts", typeof(UiTextResource), typeof(Prompt), new PropertyMetadata(null));



        public void InitializeUiText()
        {
            UiTexts = new UiTextResource();
            UiTexts["Email"] = new UILanguage();
            UiTexts["Email"][UILanguageOptions.enUS] = "Email";
            UiTexts["Email"][UILanguageOptions.zhCN] = "邮箱";


        }
    }
}

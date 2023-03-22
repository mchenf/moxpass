using moxpass_gui.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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

            InitializeUiText();
            InitializeComponent();

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
            
            UiTexts["Email", UILanguageOptions.enUS] = "Email";
            UiTexts["Email", UILanguageOptions.zhCN] = "邮箱";

            UiTexts["Password", UILanguageOptions.enUS] = "Password";
            UiTexts["Password", UILanguageOptions.zhCN] = "密码";

            UiTexts["Login", UILanguageOptions.enUS] = "Login";
            UiTexts["Login", UILanguageOptions.zhCN] = "登录";

            UiTexts["Register", UILanguageOptions.enUS] = "Register";
            UiTexts["Register", UILanguageOptions.zhCN] = "注册";

            UiTexts["Cancel", UILanguageOptions.enUS] = "Cancel";
            UiTexts["Cancel", UILanguageOptions.zhCN] = "退出";

            Debug.Print("Initialized UI Text");
        }

        public void cbxLanguage_Selected(object sender, RoutedEventArgs e)
        {
            Debug.Print("Language selected.");
            ComboBox elem = (ComboBox)sender;



            ComboBoxItem box = elem.SelectedItem as ComboBoxItem;


            if (box == null || UiTexts == null || txbEmail == null) { return; }


            var capture = UILanguageOptions.enUS;
            Enum.TryParse(box.Name, out capture);
            UiTexts.CurrentLangSetting = capture;
            txbEmail.Text = UiTexts["Email"];
            txbPass.Text = UiTexts["Password"];
            bnLogin.Content = UiTexts["Login"];
            bnRegister.Content = UiTexts["Register"];
            bnCancel.Content = UiTexts["Cancel"];

            Debug.Print("Updating UI, or at least trying to...");
        }
    }
}

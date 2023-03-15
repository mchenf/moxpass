using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace moxpass_gui.ViewModels
{
    public class PromptViewModel : INotifyPropertyChanged
    {
		private string email = string.Empty;

		public string Email
		{
			get { return email; }
			set 
			{
                email = value;
				notifyPropChanged();
			}
		}

		private SecureString? password = null;

		public SecureString? Password
		{
			get { return password; }
			set { password = value; notifyPropChanged(); }
		}

        public event PropertyChangedEventHandler? PropertyChanged;

		private protected void notifyPropChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}

using PhoneCompany.ViewModels.Base;
using System.Windows.Controls;

namespace PhoneCompany.ViewModels
{
    public class SearchWindowViewModel : ViewModel
    {
        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
    }
}

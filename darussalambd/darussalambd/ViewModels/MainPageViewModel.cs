using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Windows.Input;

namespace darussalambd.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { protected set; get; }
        public ICommand SignupCommand { protected set; get; }

        public MainPageViewModel()
        {
            LoginCommand = new DelegateCommand(OnLoginCommand);
            SignupCommand = new DelegateCommand(OnSignupCommand);
        }

        private async void OnSignupCommand()
        {
            await App.Current.MainPage.DisplayAlert("Test Title", "Test", "OK");
            
        }

        private void OnLoginCommand()
        {
          //  throw new NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}

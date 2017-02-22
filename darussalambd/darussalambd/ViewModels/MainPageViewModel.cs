using darussalambd.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Windows.Input;
using System;
using System.Threading.Tasks;
using darussalambd.Services;
using System.Linq;
using Prism.Events;

namespace darussalambd.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        string cont = "tbl_DarussalamMobileUser";
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

        private tbl_DarussalamMobileUser _selectedUser;
        public tbl_DarussalamMobileUser SelectedUser
        {
            get { return _selectedUser; }
            set { SetProperty(ref _selectedUser, value); }
        }

        private List<tbl_DarussalamMobileUser> _selectedUserList;
        public List<tbl_DarussalamMobileUser> SelectedUserList
        {
            get { return _selectedUserList; }
            set { SetProperty(ref _selectedUserList, value); }
        }



        //private string _title = "MainPage";
        //public string Title
        //{
        //    get { return _title; }
        //    set { SetProperty(ref _title, value); }
        //}

        private bool _isActive = false;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {

                SetProperty(ref _isActive, value);
            }
        }



        public ICommand LoginCommand { protected set; get; }
        public ICommand SignupCommand { protected set; get; }

        public MainPageViewModel(INavigationService navigationService, IEventAggregator ea)
        {
            _navigationService = navigationService;
           LoginCommand = new DelegateCommand(OnLoginCommand);

         //   LoginCommand = new DelegateCommand(OnLoginCommand).ObservesCanExecute((p) => IsActive);
          //  ea.GetEvent<MyEvent>().Subscribe(Handled);

            SignupCommand = new DelegateCommand(OnSignupCommand);
            LoadAllUserAsyn();
        }

        private async Task  LoadAllUserAsyn()
        {
            var _loginService = new LoginServices();
            SelectedUserList = await _loginService.GetUsersAsync(cont);
        }

        private async void OnSignupCommand()
        {
            var item = SelectedUserList.FirstOrDefault(x => x.EmailAddress == Email);
            if (item == null)
            {
                SelectedUser = new Models.tbl_DarussalamMobileUser();
                SelectedUser.EmailAddress = Email;
                SelectedUser.Password = Password;
                SelectedUser.IsActive = true;
                SelectedUser.EntryDate = DateTime.Now;
                var _loginService = new LoginServices();
                await _loginService.PostUserAsync(SelectedUser, cont);
                await App.Current.MainPage.DisplayAlert("Registration", "Thank you for your registration.", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Registration", "This User Already Exist, Please login.", "OK");
            }
          
            
        }

        private async void OnLoginCommand()
        {
            var _loginService = new LoginServices();
            SelectedUserList = await _loginService.GetUsersAsync(cont);

            var item = SelectedUserList.FirstOrDefault(x => x.EmailAddress == Email && x.Password == Password);
            if (item == null)
            {
                await App.Current.MainPage.DisplayAlert("Login", "Please enter your correct email and password.", "OK");
            }
            else
            {
             //   _navigationService = new 
                _navigationService.NavigateAsync("KarimBooks");
            }

           // _navigationService.NavigateAsync("KarimBooks");

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

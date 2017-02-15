using darussalambd.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Windows.Input;
using System;
using System.Threading.Tasks;
using darussalambd.Services;

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

        





        public ICommand LoginCommand { protected set; get; }
        public ICommand SignupCommand { protected set; get; }

        public MainPageViewModel()
        {
            LoginCommand = new DelegateCommand(OnLoginCommand);
            SignupCommand = new DelegateCommand(OnSignupCommand);
            LoadAllUserAsyn();
        }

        private async Task  LoadAllUserAsyn()
        {
            string cont = "tbl_DarussalamMobileUser";
            var _loginService = new LoginServices();
            SelectedUserList = await _loginService.GetUsersAsync(cont);
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

using darussalambd.Models;
using darussalambd.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace darussalambd.ViewModels
{
    public class KarimBooksViewModel : BindableBase, INavigationAware
    {

        private List<tbl_DarusSalamBook> _selectedBookList;
        public List<tbl_DarusSalamBook> SelectedBookList
        {
            get { return _selectedBookList; }
            set { SetProperty(ref _selectedBookList, value); }
        }

        private tbl_DarusSalamBook _selectedBook;
        public tbl_DarusSalamBook SelectedBook
        {
            get { return _selectedBook; }
            set { SetProperty(ref _selectedBook, value); }
        }

       // public ICommand AddToCartCommand { protected set; get; }

        public ICommand AddToCartCommand
        {
            get
            {
                return new Command((e) =>
                {
                    var item = (e as tbl_DarusSalamBook);
                    // delete logic on item
                });
            }
        }

        public KarimBooksViewModel()
        {
            // AddToCartCommand = new DelegateCommand(OnAddToCartCommand);
            LoadAllBookAsyn();
        }

        private async Task LoadAllBookAsyn()
        {
           
            string cont = "tbl_DarusSalamBook";
            var _loginService = new BookServices();
            SelectedBookList = await _loginService.GetUsersAsync(cont);
        }

        private void OnAddToCartCommand()
        {
          //  throw new NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
          //  throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
          //  throw new NotImplementedException();
        }

    }
}

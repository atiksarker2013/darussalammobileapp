using darussalambd.Models;
using darussalambd.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace darussalambd.ViewModels
{
    public class KarimBooksViewModel : BindableBase, INavigationAware
    {


        INavigationService _navigationService;

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value); }
        }


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
            set {
                    SetProperty(ref _selectedBook, value);
                if (_selectedBook!=null)
                {
                    var p = new NavigationParameters();
                    p.Add("id", SelectedBook.Id);
                    _navigationService.NavigateAsync("BookDetails",p);
                }
                }
        }

        private ObservableCollection<tbl_DarusSalamBook> _searchList;

        public ObservableCollection<tbl_DarusSalamBook> SearchList

        {

            get

            {

                ObservableCollection<tbl_DarusSalamBook> theCollection = new ObservableCollection<tbl_DarusSalamBook>();




                if (SelectedBookList != null)

                {

                    List<tbl_DarusSalamBook> entities = (from e in SelectedBookList
                                                         where e.Publisher.Contains(_searchText)
                                                         select e).ToList<tbl_DarusSalamBook>();

                    if (entities != null && entities.Any())

                    {
                        theCollection = new ObservableCollection<tbl_DarusSalamBook>(entities);
                    }

                }

                return theCollection;
            }

        }


        


        public ICommand SearchCommand { protected set; get; }

      

        public KarimBooksViewModel(INavigationService navigationService, IEventAggregator ea)
        {

            _navigationService = navigationService;
            SearchCommand = new DelegateCommand(OnSearchCommand);
            LoadAllBookAsyn();
        }

        private async Task LoadAllBookAsyn()
        {
           
            string cont = "tbl_DarusSalamBook";
            var _loginService = new BookServices();
            SelectedBookList = await _loginService.GetUsersAsync(cont);
        }

        private void OnSearchCommand()
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

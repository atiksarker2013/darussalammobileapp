using System;
using Prism.Mvvm;
using Prism.Navigation;

namespace darussalambd.ViewModels
{
    
    public class BookDetailsViewModel : BindableBase, INavigationAware
    {
        private int _bookId;
        public int BookId
        {
            get { return _bookId; }
            set { SetProperty(ref _bookId, value); }
        }

        public BookDetailsViewModel()
        {

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("id"))
                BookId = (int)parameters["id"];
        }
    }
}

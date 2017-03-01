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

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _writer;
        public string Writer
        {
            get { return _writer; }
            set { SetProperty(ref _writer, value); }
        }

        private string _publisher;
        public string Publisher
        {
            get { return _publisher; }
            set { SetProperty(ref _publisher, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
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
           // if (parameters.ContainsKey("id"))
                BookId = (int)parameters["id"];
            Title =  (string)parameters["title"];
            Writer = (string)parameters["author"];
            Publisher = (string)parameters["publisher"];
            Description = (string)parameters["description"];
            Price = (decimal)parameters["price"];

        }
    }
}

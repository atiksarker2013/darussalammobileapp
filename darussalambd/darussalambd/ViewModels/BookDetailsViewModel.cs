using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Events;


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

        INavigationService _navigationService;

        public DelegateCommand AddToCartCommand { protected set; get; }

        IEventAggregator _ea;

        public BookDetailsViewModel(INavigationService navigationService, IEventAggregator ea)
        {
            _ea = ea;
            _navigationService = navigationService;
            AddToCartCommand = new DelegateCommand(OnAddToCartCommand);
        }

        private void OnAddToCartCommand()
        {
           // _ea.GetEvent<MyEvent>().Publish("hello");
            _navigationService.GoBackAsync();
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

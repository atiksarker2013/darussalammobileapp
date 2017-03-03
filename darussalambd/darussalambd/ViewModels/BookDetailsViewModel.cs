using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Events;
using darussalambd.Models;
using darussalambd.Services;

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

        private int _orderQty;
        public int OrderQty
        {
            get { return _orderQty; }
            set { SetProperty(ref _orderQty, value); }
        }



        private tbl_DarussalamMobileCart _selectedMobileCart;
        public tbl_DarussalamMobileCart SelectedMobileCart
        {
            get { return _selectedMobileCart; }
            set { SetProperty(ref _selectedMobileCart, value); }
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
            SelectedMobileCart = new tbl_DarussalamMobileCart();
            SelectedMobileCart.BookId = BookId;
            SelectedMobileCart.CUstomerId = AppGlobalVar.CustomerId;
            SelectedMobileCart.OrderId = AppGlobalVar.OrderId;
            SelectedMobileCart.BookName = Title;
            SelectedMobileCart.Price = Price;
            SelectedMobileCart.Qty = OrderQty;
            SelectedMobileCart.UnitTotal = Price * OrderQty;
            SelectedMobileCart.SubmitStatus = false;
            SelectedMobileCart.ProcessStatus = false;
            SelectedMobileCart.EntryDate = DateTime.Now;

            var _cartService = new CartService();
            string cont = "tbl_DarussalamMobileCart";
             _cartService.PostCartAsync(SelectedMobileCart, cont);
            App.Current.MainPage.DisplayAlert("Cart", "Item added on your cart.", "OK");

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

            OrderQty = 1;

        }
    }
}

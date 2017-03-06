using darussalambd.Models;
using darussalambd.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace darussalambd.ViewModels
{
    public class CartDetailsViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;

        private List<tbl_DarussalamMobileCart> _selectedBookList;
        public List<tbl_DarussalamMobileCart> SelectedBookList
        {
            get { return _selectedBookList; }
            set { SetProperty(ref _selectedBookList, value); }
        }

        private tbl_DarussalamMobileCart _selectedMobileCart;
        public tbl_DarussalamMobileCart SelectedMobileCart
        {
            get { return _selectedMobileCart; }
            set { SetProperty(ref _selectedMobileCart, value); }
        }

        public CartDetailsViewModel(INavigationService navigationService, IEventAggregator ea)
        {
            _navigationService = navigationService;
            LoadOrderItem();
        }

        private async Task LoadOrderItem()
        {
            string cont = "tbl_DarussalamMobileCart" + "?orderid="+
                AppGlobalVar.OrderId;
            var _loginService = new CartService();
            SelectedBookList = await _loginService.GetCartsAsync(cont);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}

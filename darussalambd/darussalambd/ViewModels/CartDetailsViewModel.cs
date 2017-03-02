using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace darussalambd.ViewModels
{
    public class CartDetailsViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;

        public CartDetailsViewModel(INavigationService navigationService, IEventAggregator ea)
        {
            _navigationService = navigationService;
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

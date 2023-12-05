using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Common.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace PlanBell.ViewModels.Pages
{
    public class SettingsViewModel : ObservableObject, INavigationAware
    {
        private readonly INavigationService _navigationService;

        public SettingsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom()
        {
            // Add implementation here
        }

        public void OnNavigatedTo()
        {
            // Add implementation here
        }
    }
}

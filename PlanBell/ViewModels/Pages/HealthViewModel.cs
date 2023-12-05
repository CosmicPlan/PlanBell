using CommunityToolkit.Mvvm.ComponentModel;
using PlanBell.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Common.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace PlanBell.ViewModels.Pages
{
    public class HealthViewModel : ObservableObject, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly ITestWindowService _testWindowService;

        public HealthViewModel(
            INavigationService navigationService,
            ITestWindowService testWindowService
        )
        {
            _navigationService = navigationService;
            _testWindowService = testWindowService;
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

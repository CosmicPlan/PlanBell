using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlanBell.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf.Ui.Common.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace PlanBell.ViewModels.Pages
{
    public class HomeViewModel : ObservableObject, INavigationAware
    {
        private readonly INavigationService _navigationService;

        private readonly ITestWindowService _testWindowService;

        public HomeViewModel(
       INavigationService navigationService,
       ITestWindowService testWindowService
   )
        {
            _navigationService = navigationService;
            _testWindowService = testWindowService;
        }

        public void OnNavigatedFrom()
        {
            System.Diagnostics.Debug.WriteLine(
              $"INFO | {typeof(HomeViewModel)} navigated",
              "Wpf.Ui.Demo"
          );
        }

        public void OnNavigatedTo()
        {
            System.Diagnostics.Debug.WriteLine(
          $"INFO | {typeof(HomeViewModel)} navigated",
          "Wpf.Ui.Demo"
      );
        }
    }
}
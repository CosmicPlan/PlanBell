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
    /// <summary>
    /// 番茄工作法ViewModel
    /// </summary>
    public class PomodoroWorkViewModel : ObservableObject, INavigationAware
    {
        private readonly INavigationService _navigationService;

        private readonly ITestWindowService _testWindowService;

        public PomodoroWorkViewModel(
       INavigationService navigationService,
       ITestWindowService testWindowService
   )
        {
            _navigationService = navigationService;
            _testWindowService = testWindowService;
        }

        public void OnNavigatedFrom()
        {


        }

        public void OnNavigatedTo()
        {

        }
    }
}

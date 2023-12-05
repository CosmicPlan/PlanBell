using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlanBell.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf.Ui.Mvvm.Contracts;

namespace PlanBell.Services
{
    internal class ApplicationHostService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly INavigationService _navigationService;
        private readonly IPageService _pageService;
        private readonly IThemeService _themeService;
        private readonly ITaskBarService _taskBarService;
        private INavigationWindow _navigationWindow;

        public ApplicationHostService(
        IServiceProvider serviceProvider,
        INavigationService navigationService,
        IPageService pageService,
        IThemeService themeService,
        ITaskBarService taskBarService
            )
        {
            _serviceProvider = serviceProvider;
            _navigationService = navigationService;
            _pageService = pageService;
            _themeService = themeService;
            _taskBarService = taskBarService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            PrepareNavigation();
            await HandleActivationAsync();
        }

        private async Task HandleActivationAsync()
        {
            await Task.CompletedTask;

            // 检查应用程序是否已经启动，如果没有则创建导航窗口
            if (!Application.Current.Windows.OfType<MainWindow>().Any())
            {
                _navigationWindow =
                 _serviceProvider.GetService(typeof(INavigationWindow)) as INavigationWindow;
                _navigationWindow!.ShowWindow();
            }
        }

        private void OnNavigationWindowLoaded(object sender, RoutedEventArgs e)
        {
            if (sender is not MainWindow navigationWindow)
            {
                return;
            }

            // 加载导航窗口时，如果应用程序已经启动，则显示导航窗口
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        private void PrepareNavigation()
        {
            _navigationService.SetPageService(_pageService);
        }
    }
}
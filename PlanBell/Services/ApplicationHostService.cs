using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlanBell.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlanBell.Services
{
    internal class ApplicationHostService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        public ApplicationHostService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await HandleActivationAsync();

        }
        private async Task HandleActivationAsync()
        {
            await Task.CompletedTask;

            // 检查应用程序是否已经启动，如果没有则创建导航窗口
            if (!Application.Current.Windows.OfType<MainWindow>().Any())
            {
                var navigationWindow = _serviceProvider.GetRequiredService<MainWindow>();
                navigationWindow.Loaded += OnNavigationWindowLoaded;
                navigationWindow.Show();
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
    }
}
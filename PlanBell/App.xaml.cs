// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlanBell.Services;
using PlanBell.Services.IServices;
using PlanBell.ViewModels.Pages;
using PlanBell.ViewModels.Windows;
using PlanBell.Views.Pages;
using PlanBell.Views.Windows;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using Wpf.Ui;
using Wpf.Ui.Mvvm.Contracts;
using Wpf.Ui.Mvvm.Services;

namespace PlanBell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        // The.NET Generic Host provides dependency injection, configuration, logging, and other services.
        // https://docs.microsoft.com/dotnet/core/extensions/generic-host
        // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
        // https://docs.microsoft.com/dotnet/core/extensions/configuration
        // https://docs.microsoft.com/dotnet/core/extensions/logging
        private static readonly IHost _host = Host
            .CreateDefaultBuilder()
            .ConfigureAppConfiguration(c => { c.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)); })
            .ConfigureServices((context, services) =>
            {
                services.AddHostedService<ApplicationHostService>();
                // 主题操作
                services.AddSingleton<IThemeService, ThemeService>();
                // 任务栏操作
                services.AddSingleton<ITaskBarService, TaskBarService>();
                services.AddSingleton<ISnackbarService, SnackbarService>();
                // 对话框服务
                services.AddSingleton<IDialogService, DialogService>();

                // 托盘图标
                services.AddSingleton<INotifyIconService, CustomNotifyIconService>();

                // 页面解析程序服务
                services.AddSingleton<IPageService, PageService>();
                // 页面解析程序服务
                services.AddSingleton<ITestWindowService, TestWindowService>();
                services.AddSingleton<INavigationService, NavigationService>();

                //// 包含导航的服务，与INavigationWindow相同。。。但没有窗户
                //services.AddSingleton<INavigationService, NavigationService>();
                services.AddScoped<INavigationWindow, MainWindow>();
                services.AddScoped<MainWindowViewModel>();

                services.AddScoped<Views.Pages.Home>();
                services.AddScoped<HomeViewModel>();

                services.AddScoped<Views.Pages.PomodoroWork>();
                services.AddScoped<PomodoroWorkViewModel>();

                services.AddScoped<Views.Pages.SchedulePlan>();
                services.AddScoped<SchedulePlanViewModel>();

                services.AddScoped<Views.Pages.Health>();
                services.AddScoped<HealthViewModel>();

                services.AddScoped<Views.Pages.Settings>();
                services.AddScoped<SettingsViewModel>();

            }).Build();

        /// <summary>
        /// Gets registered service.
        /// </summary>
        /// <typeparam name="T">Type of the service to get.</typeparam>
        /// <returns>Instance of the service or <see langword="null"/>.</returns>
        public static T GetService<T>()
            where T : class
        {
            return _host.Services.GetService(typeof(T)) as T;
        }

        /// <summary>
        /// Occurs when the application is loading.
        /// </summary>
        private void OnStartup(object sender, StartupEventArgs e)
        {
            _host.Start();
        }

        /// <summary>
        /// Occurs when the application is closing.
        /// </summary>
        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();

            _host.Dispose();
        }

        /// <summary>
        /// Occurs when an exception is thrown by an application but not handled.
        /// </summary>
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // For more info see https://docs.microsoft.com/en-us/dotnet/api/system.windows.application.dispatcherunhandledexception?view=windowsdesktop-6.0
        }
    }
}
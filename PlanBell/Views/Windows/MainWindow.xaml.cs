using PlanBell.ViewModels.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf.Ui;
using Wpf.Ui.Appearance;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;
using Wpf.Ui.Mvvm.Services;
using Wpf.Ui.TaskBar;

namespace PlanBell.Views.Windows
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : INavigationWindow
    {
        private bool _initialized = false;
        private readonly IThemeService _themeService;
        private readonly ITaskBarService _taskBarService;
        public MainWindowViewModel ViewModel { get; }

        public MainWindow(
                MainWindowViewModel viewModel,
        INavigationService navigationService,
        IPageService pageService,
        IThemeService themeService,
        ITaskBarService taskBarService,
        ISnackbarService snackbarService,
        IDialogService dialogService

            )
        {
            ViewModel = viewModel;
            DataContext = this;
            _themeService = themeService;
            _taskBarService = taskBarService;
            InitializeComponent();

            //.
            navigationService.SetNavigationControl(RootNavigation);

            // 允许您在其他页面或窗口中使用在此窗口中定义的Snackbar控件
            snackbarService.SetSnackbarControl(RootSnackbar);
            dialogService.SetDialogControl(RootDialog);

            Loaded += (_, _) => InvokeSplashScreen();
        }

        private void InvokeSplashScreen()
        {
            if (_initialized)
                return;

            _initialized = true;

            RootMainGrid.Visibility = Visibility.Collapsed;
            RootWelcomeGrid.Visibility = Visibility.Visible;

            _taskBarService.SetState(this, TaskBarProgressState.Indeterminate);

            Task.Run(async () =>
            {
                await Task.Delay(1000);

                await Dispatcher.InvokeAsync(() =>
                {
                    RootWelcomeGrid.Visibility = Visibility.Hidden;
                    RootMainGrid.Visibility = Visibility.Visible;

                    Navigate(typeof(Pages.Home));

                    _taskBarService.SetState(this, TaskBarProgressState.None);
                });

                return true;
            });
        }

        public Frame GetFrame() => RootFrame;

        public bool Navigate(Type pageType) => RootNavigation.Navigate(pageType);

        public void SetPageService(IPageService pageService) =>
        RootNavigation.PageService = pageService;

        public void ShowWindow() => Show();

        public void CloseWindow() => Close();

        INavigation INavigationWindow.GetNavigation() => RootNavigation;

        private void RootNavigation_OnNavigated(INavigation sender, RoutedNavigationEventArgs e)
        {
            RootFrame.Margin = new Thickness(
                left: 0,
                top: sender?.Current?.PageTag == "dashboard" ? -69 : 0,
                right: 0,
                bottom: 0
            );
        }

        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);
            if (WindowState == WindowState.Minimized)
            {
                Hide();
            }
        }

        /// <summary>
        /// 托盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrayMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is not Wpf.Ui.Controls.MenuItem menuItem)
                return;

            System.Diagnostics.Debug.WriteLine(
                $"DEBUG | WPF UI Tray clicked: {menuItem.Tag}",
                "Wpf.Ui.Demo"
            );
        }

        private void NavigationButtonTheme_OnClick(object sender, RoutedEventArgs e)
        {
            _themeService.SetTheme(
                _themeService.GetTheme() == ThemeType.Dark ? ThemeType.Light : ThemeType.Dark
            );
        }

        private void NotifyIcon_LeftClick(NotifyIcon sender, RoutedEventArgs e)
        {
            Show();
            WindowState = WindowState.Normal;
        }
    }
}
using PlanBell.ViewModels.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Common.Interfaces;

namespace PlanBell.Views.Pages
{
    /// <summary>
    ///日程计划 SchedulePlan.xaml 的交互逻辑
    /// </summary>
    public partial class SchedulePlan : INavigableView<SchedulePlanViewModel>
    {
        public SchedulePlanViewModel ViewModel { get; }

        public SchedulePlan(SchedulePlanViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }
    }
}

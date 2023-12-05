using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf.Ui.Mvvm.Contracts;

namespace PlanBell.Services
{
    /// <summary>
    /// 提供导航页面的服务
    /// </summary>
    public class PageService : IPageService
    { /// <summary>
      /// 提供页面实例的服务.
      /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Creates new instance and attaches the <see cref="IServiceProvider"/>.
        /// </summary>
        public PageService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public T? GetPage<T>() where T : class
        {
            if (!typeof(FrameworkElement).IsAssignableFrom(typeof(T)))
            {
                throw new InvalidOperationException("该页面应该是WPF控件.");
            }

            return (T?)_serviceProvider.GetService(typeof(T));
        }

        /// <inheritdoc />
        public FrameworkElement? GetPage(Type pageType)
        {
            if (!typeof(FrameworkElement).IsAssignableFrom(pageType))
            {
                throw new InvalidOperationException("该页面应该是WPF控件.");
            }

            return _serviceProvider.GetService(pageType) as FrameworkElement;
        }
    }
}
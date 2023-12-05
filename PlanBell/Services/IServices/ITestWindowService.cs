using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanBell.Services.IServices
{
    public interface ITestWindowService
    {
        public void Show(Type windowType);

        public T Show<T>() where T : class;
    }
}
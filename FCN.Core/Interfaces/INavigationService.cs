using System;
using System.Collections.Generic;
using System.Text;

namespace FCN.Core.Interfaces
{
    public interface INavigationService
    {
        void NavigateTo<T>(int Token);
        void NavigateTo<T>();
    }
}

using System;
using System.Runtime.CompilerServices;
using MvvmCross.ViewModels;
namespace SDC.Coach.ViewModels
{
    public abstract class ViewModelBase : MvxViewModel
    {
        protected Boolean SetProperty<T>(
            ref T storage,
            T value,
            [CallerMemberName]String propertyName = null,
            Action onChanged = null)
        {
            if (!base.SetProperty<T>(ref storage, value, propertyName))
            {
                return false;
            }

            onChanged?.Invoke();
            return true;
        }
    }
}

using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace TD1_Xamarin.ViewModels
{
    class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
        }
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}

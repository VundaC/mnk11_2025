using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Practice.Views;

namespace Practice.Views
{
    public partial class MainPageViewModel : BaseViewModel
    {
        public double Radius { get => _radius; set => SetProperty(ref _radius, value); }
        private double _radius;
    }
}

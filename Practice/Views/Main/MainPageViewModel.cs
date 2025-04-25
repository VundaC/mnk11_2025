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
        private double _radius = 10d;
        
        public double BorderWidth { get => _borderWidth; set => SetProperty(ref _borderWidth, value); }
        private double _borderWidth = 1d;

        public byte Red { get => _red; set => SetPropertyAndNotify(ref _red, value, notifyList: [nameof(Color)]); }
        private byte _red;
        
        public byte Green { get => _green; set => SetPropertyAndNotify(ref _green, value, notifyList: [nameof(Color)]); }
        private byte _green;
        
        public byte Blue { get => _blue; set => SetPropertyAndNotify(ref _blue, value, notifyList: [nameof(Color)]); }
        private byte _blue;
        
        public float Alpha { get => _alpha; set => SetPropertyAndNotify(ref _alpha, value, notifyList: [nameof(Color)]); }
        private float _alpha = 1;
        
        public Color Color => Color.FromRgb(Red, Green, Blue).WithAlpha(Alpha);
    }
}

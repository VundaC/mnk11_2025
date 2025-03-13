using Practice.Interfaces;
using Microsoft.Maui;

namespace Practice.Services.Implementations
{
    public class PlatformService : IPlatform
    {
        public string AppVersion => $"{AppInfo.VersionString} ({AppInfo.BuildString})";
        public string DeviceName => DeviceInfo.Name;
        public PlatformType Platform => GetPlatform();

        private PlatformType GetPlatform()
        {
            switch (DeviceInfo.Platform)
            {
                case var platform when platform == DevicePlatform.iOS:
                    return PlatformType.iOS;
                case var platform when platform == DevicePlatform.Android:
                    return PlatformType.Android;
                case var platform when platform == DevicePlatform.MacCatalyst:
                    return PlatformType.MacCatalyst;
                case var platform when platform == DevicePlatform.WinUI:
                    return PlatformType.Windows;
                default:
                    throw new NotSupportedException("Unsupported platform");
            }
        }


    }
}
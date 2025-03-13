namespace Practice.Interfaces
{
    public interface IPlatformService
    {
        string AppVersion { get; }
        string DeviceName { get; }
        PlatformType Platform { get; }
    }

    public enum PlatformType
    {
        iOS,
        Android,
        MacCatalyst,
        Windows
    }
}
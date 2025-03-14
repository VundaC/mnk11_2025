using Practice.Interfaces;

namespace Practice.Services.Implementations;

public class PreferenceService : IPreference
{
    public void Save<T>(string key, T value)
    {
        Preferences.Default.Set(key, value);
    }
    public async Task SaveSecureAsync<T>(string key, T value)
    {
        await SecureStorage.Default.SetAsync(key, value?.ToString());
    }
    public T Get<T>(string key, T defaultValue = default)
    {
        string value = Preferences.Default.Get(key, defaultValue.ToString());
        try
        {
            return (T)Convert.ChangeType(value, typeof(T)); // Конвертуємо string у T
        }
        catch
        {
            return default;
        }
    }
    public async Task<T> GetSecureAsync<T>(string key, T defaultValue = default)
    {
        string value = await SecureStorage.Default.GetAsync(key);
        try
        {
            return (T)Convert.ChangeType(value, typeof(T)); // Конвертуємо string у T
        }
        catch
        {
            return default;
        }
    }
    public bool DeleteSecure(string key)
    {
        return SecureStorage.Default.Remove(key);
    }
    public void Delete(string key)
    {
        Preferences.Default.Remove(key);
    }
    public void DeleteAll(bool deleteAllPreferences, bool deleteAllSecurePreferences)
    {
        if (deleteAllPreferences) Preferences.Default.Clear();
        if (deleteAllSecurePreferences) SecureStorage.Default.RemoveAll();
    }
}


using Practice.Interfaces;
using System.Text.Json;

namespace Practice.Services.Implementations;

public class PreferenceService : IPreference
{
    public void Save<T>(string key, T value)
    {
        Preferences.Default.Set(key, value);
    }
    public async Task SaveSecureAsync<T>(string key, T value)
    {
        string valueString = JsonSerializer.Serialize(value);
        await SecureStorage.Default.SetAsync(key, valueString);
    }
    public T Get<T>(string key, T defaultValue = default)
    {
        var value = Preferences.Default.Get(key, defaultValue);
        try
        {
            return value; 
        }
        catch
        {
            return default;
        }
    }
    public async Task<T> GetSecureAsync<T>(string key, T defaultValue = default)
    {
        try
        {
            string value = await SecureStorage.Default.GetAsync(key);
            if (value == null) return defaultValue;
            return JsonSerializer.Deserialize<T>(value);
        }
        catch
        {
            return defaultValue;

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


namespace Practice.Interfaces;

public interface IPreference
{
    void Save<T>(string key, T value);
    Task SaveSecureAsync<T>(string key, T value);
    T Get<T>(string key, T defaultValue = default);
    Task<T> GetSecureAsync<T>(string key, T defaultValue = default);
    bool DeleteSecure(string key);
    void Delete(string key);
    void DeleteAll(bool deleteAllPreferences, bool deleteAllSecurePreferences);
}

namespace Core.Services;

public static class LocalStorageExtensions
{
    public static async Task<SettingsModel> Load(this ILocalStorage localStorage, int id)
    {
        var item = await localStorage.TryLoad(id);
        if (item != null)
        {
            return item;
        }

        throw new InvalidOperationException($"Could not load object of type [{typeof(SettingsModel)}] with id [{id}].");
    }
}
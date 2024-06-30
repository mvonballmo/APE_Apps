namespace Core.Services;

public interface ILocalStorage
{
    // TODO Make the interface generic rather than SettingsModel-specifics
    // TODO Add documentation

    Task<SettingsModel?> TryLoad(int id);

    Task<bool> Save(SettingsModel settingsModel);

    Task<bool> Delete(SettingsModel settingsModel);

    Task<List<SettingsModel>> LoadAll();

    Task<bool> DeleteAll();
    Task Initialize();
}
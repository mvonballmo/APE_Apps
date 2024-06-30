using Core.Models;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Tests;

[TestFixture]
public class LocalStorageServiceTests : TestsBase
{
    [Test]
    public async Task TestSaveAndLoad()
    {
        var localStorage = await GetLocalStorage();
        var settingsModel = CreateSettingsModel();

        Assert.That(settingsModel.Id, Is.Null);

        var saved = await localStorage.Save(settingsModel);
        Assert.Multiple(() =>
        {
            Assert.That(saved, "Object was not saved");
            Assert.That(settingsModel.Id, Is.Not.Zero);
        });

        var loadedSettingsModel = await localStorage.Load(settingsModel.Id.Value);

        Assert.That(loadedSettingsModel.Id, Is.EqualTo(settingsModel.Id));
    }

    [Test]
    public async Task TestSaveAndTryLoad()
    {
        var localStorage = await GetLocalStorage();
        var settingsModel = CreateSettingsModel();

        Assert.That(settingsModel.Id, Is.Null);

        var saved = await localStorage.Save(settingsModel);
        Assert.Multiple(() =>
        {
            Assert.That(saved, "Object was not saved");
            Assert.That(settingsModel.Id, Is.Not.Zero);
        });

        var loadedSettingsModel = await localStorage.TryLoad(settingsModel.Id.Value);

        Assert.Multiple(() =>
        {
            Assert.That(loadedSettingsModel, Is.Not.Null, $"Could not load item with Id = [{settingsModel.Id}]");
            Assert.That(loadedSettingsModel!.Id, Is.EqualTo(settingsModel.Id));
        });
    }

    [Test]
    public async Task TestSaveLoadAndDelete()
    {
        var localStorage = await GetLocalStorage();
        var settingsModel = CreateSettingsModel();

        Assert.That(settingsModel.Id, Is.Null);

        var saved = await localStorage.Save(settingsModel);
        Assert.Multiple(() =>
        {
            Assert.That(saved, "Object was not saved");
            Assert.That(settingsModel.Id, Is.Not.Zero);
        });

        var loadedSettingsModel = await localStorage.Load(settingsModel.Id.Value);

        Assert.That(loadedSettingsModel.Id, Is.EqualTo(settingsModel.Id));

        var deleted = await localStorage.Delete(loadedSettingsModel);

        Assert.That(deleted, "Object was not deleted.");

        var settingsModelWithId = await localStorage.TryLoad(settingsModel.Id.Value);

        Assert.That(settingsModelWithId, Is.Null, "Object should no longer exist.");
    }

    [Test]
    public async Task TestDeleteAndLoadAll()
    {
        var localStorage = await GetLocalStorage();
        var deleted = await localStorage.DeleteAll();

        Assert.That(deleted, "Could not delete all objects.");

        var settingsModels = await localStorage.LoadAll();

        Assert.That(settingsModels.Count, Is.EqualTo(0));

        for (var i = 0; i < 5; i++)
        {
            var saved = await localStorage.Save(CreateSettingsModel());

            Assert.That(saved, "Object was not saved.");
        }

        settingsModels = await localStorage.LoadAll();

        Assert.That(settingsModels.Count, Is.EqualTo(5));
    }

    protected override IServiceCollection AddServices(IServiceCollection serviceCollection)
    {
        return base.AddServices(serviceCollection)
            .AddSingleton(new LocalStorageSettings { DatabaseFilename = "LZ2Tests.db3" });
    }

    private async Task<ILocalStorage> GetLocalStorage()
    {
        var serviceProvider = CreateServiceProvider();
        var localStorage = serviceProvider.GetRequiredService<ILocalStorage>();

        await localStorage.Initialize();
        return localStorage;
    }

    private static Person CreateSettingsModel()
    {
        return new Person
        {
            FirstName = "John",
            LastName = "Doe",
            Age = 4
        };
    }
}
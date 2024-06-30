using Core.Services;

namespace Core.Tests;

public class MainPageViewModelTests : TestsBase
{
    [Test]
    public async Task TestSettingFirstName()
    {
        var viewModel = await GetMainPageViewModel();

        Assert.That(viewModel.FirstName, Is.EqualTo("Hans"));

        viewModel.FirstName = "Marco";

        Assert.That(viewModel.FirstName, Is.EqualTo("Marco"));
    }

    [Test]
    public async Task TestSettingLastName()
    {
        var viewModel = await GetMainPageViewModel();

        Assert.That(viewModel.LastName, Is.EqualTo("Muster"));

        viewModel.LastName = "von Ballmoos";

        Assert.That(viewModel.LastName, Is.EqualTo("von Ballmoos"));
    }

    [Test]
    public async Task TestIncrementTriggersChange()
    {
        var viewModel = await GetMainPageViewModel();

        var notifications = new List<string?>();

        viewModel.PropertyChanged += (_, args) => notifications.Add(args.PropertyName);

        Assert.That(viewModel.Age, Is.EqualTo(1));

        viewModel.Increment();

        Assert.That(viewModel.Age, Is.EqualTo(2));
        Assert.That(notifications, Is.EquivalentTo(new[] { "Age" }));
    }

    [Test]
    public async Task TestFullNameOnlyTriggeredWhenChangeHappens()
    {
        var viewModel = await GetMainPageViewModel();

        var notifications = new List<string?>();

        viewModel.PropertyChanged += (_, args) => notifications.Add(args.PropertyName);

        Assert.That(viewModel.LastName, Is.EqualTo("Muster"));

        viewModel.LastName = "von Ballmoos";

        Assert.That(notifications, Is.EquivalentTo(new[] { "LastName", "FullName" }));

        notifications.Clear();

        viewModel.LastName = "von Ballmoos";

        Assert.That(notifications, Is.EquivalentTo(Array.Empty<string>()));
    }

    [Test]
    public async Task TestSave()
    {
        var serviceProvider = CreateServiceProvider();
        var localStorage = serviceProvider.GetRequiredService<ILocalStorage>();

        await localStorage.Initialize();
        await localStorage.DeleteAll();

        var viewModel = await GetMainPageViewModel(serviceProvider);

        await viewModel.Save();

        var settingsModels = await localStorage.LoadAll();

        Assert.That(settingsModels, Has.Count.EqualTo(1));
    }

    [Test]
    public async Task TestEnsureModelLoaded()
    {
        var serviceProvider = CreateServiceProvider();
        var viewModel = serviceProvider.GetRequiredService<MainPageViewModel>();
        var localStorage = serviceProvider.GetRequiredService<ILocalStorage>();

        await localStorage.Initialize();
        await localStorage.DeleteAll();

        var notifications = new List<string?>();

        viewModel.PropertyChanged += (_, args) => notifications.Add(args.PropertyName);

        await viewModel.EnsureModelLoaded();

        Assert.That(notifications, Is.EquivalentTo(new[] { "SelectedItem", "FirstName", "FullName", "LastName", "FullName", "Age", "IsReady" }));
    }

    private async Task<MainPageViewModel> GetMainPageViewModel()
    {
        var serviceProvider = CreateServiceProvider();

        return await GetMainPageViewModel(serviceProvider);
    }

    private static async Task<MainPageViewModel> GetMainPageViewModel(IServiceProvider serviceProvider)
    {
        var result = serviceProvider.GetRequiredService<MainPageViewModel>();

        await result.EnsureModelLoaded();

        return result;
    }
}
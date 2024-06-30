using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Core.Services;

namespace Core;

public partial class MainPageViewModel : ViewModelBase
{
    private readonly ILocalStorage _localStorage;
    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private int _count;
    private SettingsModel? _selectedItem;

    public MainPageViewModel()
    {
        // throw new InvalidOperationException("This constructor is for detecting binding in XAML and should never be called.");
    }

    public MainPageViewModel(ILocalStorage localStorage)
    {
        _localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
    }

    public string FirstName
    {
        get => _firstName;
        set
        {
            if (SetField(ref _firstName, value))
            {
                OnPropertyChanged(nameof(FullName));
            }
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (SetField(ref _lastName, value))
            {
                OnPropertyChanged(nameof(FullName));
            }
        }
    }

    public object FullName => $"{LastName}, {FirstName}";

    public int Count
    {
        get => _count;
        set => SetField(ref _count, value);
    }

    public bool IsReady => SelectedItem != null;

    public ObservableCollection<SettingsModel> Items { get; private set; } = new();

    public SettingsModel? SelectedItem
    {
        get => _selectedItem;
        set
        {
            if (SetField(ref _selectedItem, value))
            {
                if (value != null)
                {
                    FirstName = value.FirstName;
                    LastName = value.LastName;
                    Count = value.Count;
                }
                else
                {
                    FirstName = string.Empty;
                    LastName = string.Empty;
                    Count = 0;
                }
            }
        }
    }

    public void Increment()
    {
        Count += 1;
    }

    [RelayCommand]
    public async Task EnsureModelLoaded()
    {
        if (Items.Count == 0)
        {
            try
            {
                await _localStorage.Initialize();

                var settingsModels = await _localStorage.LoadAll();

                foreach (var settingsModel in settingsModels)
                {
                    Items.Add(settingsModel);
                }

                if (Items.Count == 0)
                {
                    Items.Add(new SettingsModel());
                }

                SelectedItem = Items.First();

                OnPropertyChanged(nameof(IsReady));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    public async Task Save()
    {
        var model = SelectedItem;

        if (model == null)
        {
            throw new InvalidOperationException("Cannot save a non-existent model");
        }

        model.FirstName = FirstName;
        model.LastName = LastName;
        model.Count = Count;

        await _localStorage.Save(model);
    }

    public void Add()
    {
        var settingsModel = new SettingsModel();

        Items.Add(settingsModel);

        SelectedItem = settingsModel;
    }
}
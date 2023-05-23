namespace Albums;

public partial class MainPage : ContentPage
{
  private readonly ICounterService counterService;
  private readonly ICounterState state;
  private readonly ICounterPersistence persistence;
  private readonly IDialogService dialogService;

  public MainPage(ICounterService counterService, ICounterState state, IDialogService dialogService, ICounterPersistence persistence)
  {
    InitializeComponent();

    if (dialogService is DialogService concreteInstance)
    {
      concreteInstance.Page = this;
    }

    this.counterService = counterService;
    this.state = state;
    this.dialogService = dialogService;
    this.persistence = persistence;
  }

  private void OnCounterClicked(object sender, EventArgs e)
  {
    counterService.Increment();

    CounterBtn.Text = counterService.GetLabel();

    SemanticScreenReader.Announce(CounterBtn.Text);
  }

  async void SaveClicked(Object sender, EventArgs e)
  {
    var answer = await dialogService.AskAsync("This is the alert");

    // runs AFTER the user answers

    if (answer)
    {
      persistence.Save(state);

      await dialogService.Show("Document saved.");
    }
    else
    {
      await dialogService.Show("Document NOT saved.");
    }
  }
}


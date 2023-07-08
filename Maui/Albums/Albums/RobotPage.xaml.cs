using Albums.Core;

namespace Albums;

public partial class RobotPage : ContentPage
{
  private readonly ICounterService counterService;
  private readonly ICounterState state;
  private readonly ICounterPersistence persistence;
  private readonly IDialogService dialogService;

  public RobotPage(ICounterService counterService, ICounterState state, IDialogService dialogService, ICounterPersistence persistence)
  {
    InitializeComponent();

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

  private async void SaveClicked(object sender, EventArgs e)
  {
    await persistence.Save(state);
  }
}
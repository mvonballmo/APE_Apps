using System;
using System.Text;
using System.Windows.Input;
using Albums.Services;
using Xamarin.Forms;

namespace Albums.ViewModels
{
  public class PasswordViewModel : ViewModelBase
  {
    public PasswordViewModel()
    {
      Title = "Password";
      EncryptCommand = new Command(EncryptWithBiometric);
      DecryptCommand = new Command(DecryptWithBiometric);
    }

    public string TextToEncrypt
    {
      get => _textToEncrypt;
      set => SetProperty(ref _textToEncrypt, value);
    }

    public string Output
    {
      get => _output;
      set => SetProperty(ref _output, value);
    }

    public ICommand EncryptCommand { get; }

    public ICommand DecryptCommand { get; }

    public ICommand NavigateCommand { get; }

    private void DecryptWithBiometric()
    {
      var service = DependencyService.Get<IBiometricAuthenticationService>();
      service.Decrypt(Convert.FromBase64String(TextToEncrypt), obj => Output = Encoding.UTF8.GetString(obj), ShowBiometricError);
    }

    private void EncryptWithBiometric()
    {
      var service = DependencyService.Get<IBiometricAuthenticationService>();
      service.Encrypt(Encoding.UTF8.GetBytes(TextToEncrypt), obj => Output = Convert.ToBase64String(obj), ShowBiometricError);
    }

    private void ShowBiometricError(string obj)
    {
      Show("Biometrics", obj);
    }

    private void Show(string title, string message)
    {
      App.Services.GetInstance<IDialogService>().Show(title, message);
    }

    private string _textToEncrypt;
    private string _output;
  }
}

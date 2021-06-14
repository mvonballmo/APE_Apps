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
      EncryptCommand = new Command(EncryptWithPassword);
      DecryptCommand = new Command(DecryptWithPassword);
    }
    public string Password
    {
      get => _password;
      set => SetProperty(ref _password, value);
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

    private void DecryptWithPassword()
    {
      if (string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(TextToEncrypt))
      {
        ShowDataMissingMessage();

        return;
      }

      var (service, key) = GetEncryptionTools();
      var decryptedValue = service.Decrypt(Convert.FromBase64String(TextToEncrypt), key);

      Output = Encoding.UTF8.GetString(decryptedValue);
    }

    private void EncryptWithPassword()
    {
      if (string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(TextToEncrypt))
      {
        ShowDataMissingMessage();

        return;
      }

      var (service, key) = GetEncryptionTools();
      var encryptedValue = service.Encrypt(Encoding.UTF8.GetBytes(TextToEncrypt), key);

      Output = Convert.ToBase64String(encryptedValue);
    }

    private (IPasswordEncryptionService service, byte[] key) GetEncryptionTools()
    {
      var service = DependencyService.Get<IPasswordEncryptionService>();
      var key = service.GenerateKey(Password);

      return (service, key);
    }

    private void ShowDataMissingMessage()
    {
      Show("Data missing", "Please make sure to enter both a password and text to encrypt.");
    }

    private void Show(string title, string message)
    {
      App.Services.GetInstance<IDialogService>().Show(title, message);
    }

    private string _password;
    private string _textToEncrypt;
    private string _output;
    private readonly IDialogService _dialogService;
  }
}

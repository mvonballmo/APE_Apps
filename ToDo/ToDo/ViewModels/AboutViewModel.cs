using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ToDo.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command<string>(async url => await Browser.OpenAsync(url));
        }

        public ICommand OpenWebCommand { get; }
    }
}
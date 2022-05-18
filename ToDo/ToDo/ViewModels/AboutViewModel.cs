using System.Threading.Tasks;
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
            OpenWebCommand = new Command<Page>(async page => {
                await AskToBrowse(page);
                });

            async Task AskToBrowse(Page page)
            {
                const string Xamarin = "https://xamarin.com";
                const string DuckDuckGo = "https://duckduckgo.com";
                const string Earthli = "https://earthli.com";

                var result = await page.DisplayActionSheet("Choose Destination", "Cancel", null, Xamarin, DuckDuckGo, Earthli);

                await Browser.OpenAsync(result);
            }
        }

        public ICommand OpenWebCommand { get; }
    }
}
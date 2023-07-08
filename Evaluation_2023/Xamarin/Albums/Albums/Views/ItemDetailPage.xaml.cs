using System.ComponentModel;
using Xamarin.Forms;
using Albums.ViewModels;

namespace Albums.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}

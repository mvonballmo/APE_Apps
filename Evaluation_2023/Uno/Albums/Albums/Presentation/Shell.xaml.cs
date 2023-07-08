using Uno.Toolkit.UI;

namespace Albums.Presentation;

public sealed partial class Shell : UserControl, IContentControlProvider
{
	public Shell()
	{
		this.InitializeComponent();
	}

	public ContentControl ContentControl => Splash;
}

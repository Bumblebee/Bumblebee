using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class JavaScriptPopUpPage : Page
	{
		public JavaScriptPopUpPage(Session session) : base(session)
		{
		}

		public JavaScriptPopUpRegion Region => new JavaScriptPopUpRegion(this, By.Id("TheRegion"));

		public Dynamic<JavaScriptPopUp> PopUp => new Dynamic<JavaScriptPopUp>(this, By.Id("TheWindow"));
	}

	public class JavaScriptPopUpRegion : Block
	{
		public JavaScriptPopUpRegion(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public IClickable<JavaScriptPopUp> OpenPopUp => new Clickable<JavaScriptPopUp>(this, By.Id("TheButton"));
	}

	public class JavaScriptPopUp : Block
	{
		public JavaScriptPopUp(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public DataRegion Data => new DataRegion(this, By.ClassName("data-region"));

		public IClickable<JavaScriptPopUpRegion> Close => new Clickable<JavaScriptPopUpRegion>(this, By.ClassName("close-button"));
	}

	public class DataRegion : Block
	{
		public DataRegion(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public string Text => Tag.Text;
	}
}

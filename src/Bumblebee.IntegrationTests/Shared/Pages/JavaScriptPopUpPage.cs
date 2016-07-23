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

		public JavaScriptPopUpRegion Region
		{
			get { return new JavaScriptPopUpRegion(this, By.Id("TheRegion")); }
		}

		public JavaScriptPopUp PopUp
		{
			get { return new JavaScriptPopUp(this, By.Id("TheWindow")); }
		}
	}

	public class JavaScriptPopUpRegion : Block
	{
		public JavaScriptPopUpRegion(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public IClickable<JavaScriptPopUp> OpenPopUp
		{
			get { return new Clickable<JavaScriptPopUp>(this, By.Id("TheButton")); }
		}
	}

	public class JavaScriptPopUp : Block
	{
		public JavaScriptPopUp(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public DataRegion Data
		{
			get { return new DataRegion(this, By.ClassName("data-region")); }
		}

		public IClickable<JavaScriptPopUpRegion> Close
		{
			get { return new Clickable<JavaScriptPopUpRegion>(this, By.ClassName("close-button")); }
		}
	}

	public class DataRegion : Block
	{
		public DataRegion(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public string Text
		{
			get { return Tag.Text; }
		}
	}
}

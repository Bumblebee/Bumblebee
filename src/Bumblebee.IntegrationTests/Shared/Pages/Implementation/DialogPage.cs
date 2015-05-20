using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages.Implementation
{
	public class DialogPage : WebBlock
	{
		public DialogPage(Session session) : base(session)
		{
		}

		public IClickable<IAlertDialog> AlertButton
		{
			get { return new Clickable<AlertDialog>(this, By.Id("AlertButton")); }
		}

		public string AlertResult
		{
			get { return FindElement(By.Id("AlertResult")).Text; }
		}

		public IClickable<IAlertDialog> ConfirmButton
		{
			get { return new Clickable<AlertDialog>(this, By.Id("ConfirmButton")); }
		}

		public string ConfirmResult
		{
			get { return FindElement(By.Id("ConfirmResult")).Text; }
		}

		public IClickable<IAlertDialog> PromptButton
		{
			get { return new Clickable<AlertDialog>(this, By.Id("PromptButton")); }
		}

		public string PromptResult
		{
			get { return FindElement(By.Id("PromptResult")).Text; }
		}
	}
}

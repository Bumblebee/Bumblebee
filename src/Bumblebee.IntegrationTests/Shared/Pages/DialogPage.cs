using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class DialogPage : Page
	{
		public DialogPage(Session session) : base(session)
		{
		}

		public IClickable<IAlertDialog> AlertButton => new Clickable<AlertDialog>(this, By.Id("AlertButton"));

		public string AlertResult => FindElement(By.Id("AlertResult")).Text;

		public IClickable<IAlertDialog> ConfirmButton => new Clickable<AlertDialog>(this, By.Id("ConfirmButton"));

		public string ConfirmResult => FindElement(By.Id("ConfirmResult")).Text;

		public IClickable<IAlertDialog> PromptButton => new Clickable<AlertDialog>(this, By.Id("PromptButton"));

		public string PromptResult => FindElement(By.Id("PromptResult")).Text;
	}
}

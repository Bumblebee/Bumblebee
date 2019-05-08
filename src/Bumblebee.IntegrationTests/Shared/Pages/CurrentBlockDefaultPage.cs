using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Bumblebee.IntegrationTests.Shared.Pages
{
	public class CurrentBlockDefaultPage : Page
	{
		public CurrentBlockDefaultPage(Session session) : base(session)
		{
		}

		public IClickable<CurrentBlockNavigateToPage> LinkToNavigateToPage
		{
			get { return new Clickable<CurrentBlockNavigateToPage>(this, By.Id("linkToNavigateToPage")); }
		}

		public InnerSection InnerSection
		{
			get {  return new InnerSection(this); }
		}
	}
}
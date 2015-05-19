using System;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.KendoUI.IntegrationTests.Pages
{
	public class KendoDropDownListDemoPage : WebBlock
	{
		public KendoDropDownListDemoPage(Session session) : base(session, TimeSpan.FromSeconds(10))
		{
		}

		public ISelectBox<KendoDropDownListDemoPage> Colors
		{
			get { return new KendoDropDownList<KendoDropDownListDemoPage>(this, By.Id("color")); }
		}

		public ISelectBox Sizes
		{
			get { return new KendoDropDownList(this, By.Id("size")); }
		}
	}
}

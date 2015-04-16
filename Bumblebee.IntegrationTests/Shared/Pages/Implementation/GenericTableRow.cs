using System;
using System.Linq;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages.Implementation
{
	public class GenericTableRow : Block
	{
		private const int ItemColumnIndex = 0;
		private const int QuantityColumnIndex = 1;
		private const int PriceColumnIndex = 2;

		public GenericTableRow(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public string Item
		{
			get
			{
				return GetElements(By.TagName("td"))
					.ElementAt(ItemColumnIndex)
					.Text;
			}
		}

		public int Quantity
		{
			get
			{
				var text = GetElements(By.TagName("td"))
					.ElementAt(QuantityColumnIndex)
					.Text;

				return Int32.Parse(text);
			}
		}

		public decimal Price
		{
			get
			{
				var text = GetElements(By.TagName("td"))
					.ElementAt(PriceColumnIndex)
					.Text;

				return Decimal.Parse(text);
			}
		}
	}
}

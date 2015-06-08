using System.Collections.Generic;
using System.Linq;

using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class RadioButtons<TResult> : IRadioButtons<TResult> where TResult : IBlock
	{
		private IBlock ParentBlock { get; set; }
		private By By { get; set; }

		public RadioButtons(IBlock parent, By by)
		{
			ParentBlock = parent;
			By = by;
		}

		public virtual IEnumerable<IOption<TResult>> Options
		{
			get
			{
				return ParentBlock.Tag.FindElements(By)
					.Where(opt => opt.Displayed)
					.Select(opt => new RadioButton<TResult>(ParentBlock, opt));
			}
		}
	}
}

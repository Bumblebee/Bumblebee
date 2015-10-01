using System.Collections.Generic;
using System.Linq;

using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class RadioButtons<TResult> : IRadioButtons<TResult>
		where TResult : IBlock
	{
		private readonly IBlock _parent;
		private readonly By _by;

		public RadioButtons(IBlock parent, By @by)
		{
			_parent = parent;
			_by = @by;
		}

		public virtual IEnumerable<IOption<TResult>> Options
		{
			get
			{
				return new ElementEnumerable<RadioButton<TResult>>(_parent, _by)
					.Where(option => option.Tag.Displayed);
			}
		}
	}
}

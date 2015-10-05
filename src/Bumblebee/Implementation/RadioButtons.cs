using System.Collections.Generic;
using System.Linq;

using Bumblebee.Interfaces;
using Bumblebee.Specifications;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class RadioButtons<TResult> : IRadioButtons<TResult>
		where TResult : IBlock
	{
		protected static readonly ISpecification By = null;

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
				return new Elements<RadioButton<TResult>>(_parent, _by)
					.Where(option => option.Tag.Displayed);
			}
		}
	}
}

using System.Collections.Generic;
using System.Linq;

using Bumblebee.Extensions;
using Bumblebee.Interfaces;
using Bumblebee.Specifications;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class RadioButtons<TResult> : IRadioButtons<TResult>, IFocusable<TResult>
		where TResult : IBlock
	{
		protected static readonly ISpecification By = new Specification();

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

		/// <summary>
		/// Sets focus on the selected radio button.
		/// </summary>
		/// <returns>The type of block to return.</returns>
		public TResult SetFocus()
		{
			return SetFocus<TResult>();
		}

		/// <summary>
		/// Sets focus on the selected radio button.
		/// </summary>
		/// <typeparam name="TUResult">The type of the block the focused block or element is on.</typeparam>
		/// <returns>The type of block to return.</returns>
		public virtual TUResult SetFocus<TUResult>() where TUResult : IBlock
		{
			return Options.Selected().Single().SetFocus<TUResult>();
		}

		/// <summary>
		/// Gets the value indicating whether any radio button has focus.
		/// </summary>
		public bool HasFocus => Options.Any(option => option.HasFocus);
	}
}

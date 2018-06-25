using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class Dynamic<TBlock>
		where TBlock : IBlock
	{
		private IBlock Parent { get; }
		private By Specification { get; }

		public Dynamic(IBlock parent, By @by)
		{
			Parent = parent;
			Specification = @by;
		}

		internal TBlock Create()
		{
			return Block.Create<TBlock>(Parent, Specification);
		}
	}
}

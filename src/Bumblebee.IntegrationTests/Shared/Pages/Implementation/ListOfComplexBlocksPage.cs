using System.Collections.Generic;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.IntegrationTests.Shared.Pages.Implementation
{
	public class ComplexBlock : Block
	{
		public ComplexBlock(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public ITextField<ComplexBlock> TextField
		{
			get { return new TextField<ComplexBlock>(this, By.ClassName("text-field")); }
		}

		public ISelectBox<ComplexBlock> SelectBox
		{
			get { return new SelectBox<ComplexBlock>(this, By.ClassName("select-box")); }
		}

		public IClickable<ComplexBlock> Button
		{
			get { return new Clickable<ComplexBlock>(this, By.ClassName("do-work-button")); }
		}
	}

	public class List : Block
	{
		public List(IBlock parent, By @by) : base(parent, @by)
		{
		}

		public IEnumerable<ComplexBlock> Items
		{
			get { return new BlockEnumerable<ComplexBlock>(this, By.CssSelector("li")); }
		}
	}

	public class ListOfComplexBlocksPage : WebBlock
	{
		public ListOfComplexBlocksPage(Session session) : base(session)
		{
		}

		public List List
		{
			get { return new List(this, By.Id("TheList")); }
		}

		public string TextBoxChanged
		{
			get { return FindElement(By.Id("TextBoxChanged")).Text; }
		}

		public string DropDownClicked
		{
			get { return FindElement(By.Id("DropDownClicked")).Text; }
		}

		public string ButtonClicked
		{
			get { return FindElement(By.Id("ButtonClicked")).Text; }
		}
	}
}

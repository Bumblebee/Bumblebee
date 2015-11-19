using Bumblebee.Specifications;

using FluentAssertions;

using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Bumblebee.IntegrationTests.Specifications
{
	[TestFixture]
	public class SpecificationTests
	{
		private static readonly ISpecification By = new Specification();

		[Test]
		public void Attribute_Returns_not_null()
		{
			By
				.Attribute("first", "second")
				.Should().NotBeNull();
		}

		[Test]
		public void ClassName_Returns_not_null()
		{
			By
				.ClassName("class")
				.Should().NotBeNull();
		}

		[Test]
		public void CssSelector_Returns_not_null()
		{
			By
				.CssSelector("#css > .selector")
				.Should().NotBeNull();
		}

		[Test]
		public void Id_Returns_not_null()
		{
			By
				.Id("id")
				.Should().NotBeNull();
		}

		[Test]
		public void LinkText_Returns_not_null()
		{
			By
				.LinkText("Link Text")
				.Should().NotBeNull();
		}

		[Test]
		public void Name_Returns_not_null()
		{
			By
				.Name("name")
				.Should().NotBeNull();
		}

		[Test]
		public void Ordinal_Returns_not_null()
		{
			By
				.Ordinal(By.ClassName("class"), 3)
				.Should().NotBeNull();
		}

		[Test]
		public void PartialLinkText_Returns_not_null()
		{
			By
				.PartialLinkText("Partial Link Text")
				.Should().NotBeNull();
		}

		[Test]
		public void TagName_Returns_not_null()
		{
			By
				.TagName("tag")
				.Should().NotBeNull();
		}

		[Test]
		public void XPath_Returns_not_null()
		{
			By
				.XPath(@"\x\path")
				.Should().NotBeNull();
		}
	}
}

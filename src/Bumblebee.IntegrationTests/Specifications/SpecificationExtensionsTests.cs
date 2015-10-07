using Bumblebee.Specifications;

using FluentAssertions;

using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Bumblebee.IntegrationTests.Specifications
{
	[TestFixture]
	public class SpecificationExtensionsTests
	{
		private static readonly ISpecification Specification = null;

		[Test]
		public void Attribute_IsExtensionMethod()
		{
			Specification
				.Attribute("first", "second")
				.Should().NotBeNull();
		}

		[Test]
		public void ClassName_IsExtensionMethod()
		{
			Specification
				.ClassName("class")
				.Should().NotBeNull();
		}

		[Test]
		public void CssSelector_IsExtensionMethod()
		{
			Specification
				.CssSelector("#css > .selector")
				.Should().NotBeNull();
		}

		[Test]
		public void Id_IsExtensionMethod()
		{
			Specification
				.Id("id")
				.Should().NotBeNull();
		}

		[Test]
		public void LinkText_IsExtensionMethod()
		{
			Specification
				.LinkText("Link Text")
				.Should().NotBeNull();
		}

		[Test]
		public void Name_IsExtensionMethod()
		{
			Specification
				.Name("name")
				.Should().NotBeNull();
		}

		[Test]
		public void Ordinal_IsExtensionMethod()
		{
			Specification
				.Ordinal(Specification.ClassName("class"), 3)
				.Should().NotBeNull();
		}

		[Test]
		public void PartialLinkText_IsExtensionMethod()
		{
			Specification
				.PartialLinkText("Partial Link Text")
				.Should().NotBeNull();
		}

		[Test]
		public void TagName_IsExtensionMethod()
		{
			Specification
				.TagName("tag")
				.Should().NotBeNull();
		}

		[Test]
		public void XPath_IsExtensionMethod()
		{
			Specification
				.XPath(@"\x\path")
				.Should().NotBeNull();
		}
	}
}

using System;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;

using FluentAssertions;

using NSubstitute;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Implementation
{
    [TestFixture]
    public class BlockTests
    {
        [Test]
        public void Given_null_parent_when_constructing_block_should_throw()
        {
            Action action = () => new TestableBlock(null);
            action.ShouldThrow<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'parent')");
        }

        [Test]
        public void Given_null_specification_when_constructing_block_should_throw()
        {
            var mockParent = Substitute.For<IBlock>();
            Action action = () => new BlockWithNullSpecification(mockParent);
            action.ShouldThrow<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'by')");
        }
    }

    public class TestableBlock : Block
    {
        public TestableBlock(IBlock parent) : base(parent, By.Id("firstName"))
        { }
    }

    public class BlockWithNullSpecification : Block
    {
        public BlockWithNullSpecification(IBlock parent) : base(parent, null)
        { }
    }
}

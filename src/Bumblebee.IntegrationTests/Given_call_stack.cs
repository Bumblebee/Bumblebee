using System;
using System.Reflection;

using FluentAssertions;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests
{
	// ReSharper disable InconsistentNaming

	public class CallsGetConstructingMethodInConstructor
	{
		public MethodBase ConstructingMethod { get; private set; }

		public CallsGetConstructingMethodInConstructor()
		{
			ConstructingMethod = CallStack.GetConstructingMethod();
		}
	}

	public class InheritsFromCallsGetConstructingMethodInConstructor : CallsGetConstructingMethodInConstructor
	{
		public InheritsFromCallsGetConstructingMethodInConstructor() : base()
		{
		}
	}

	[TestFixture]
	public class Given_call_stack
	{
		[Test]
		public void When_GetCurrentMethod_is_called_Then_current_method_is_returned()
		{
			CallStack.GetCurrentMethod().Should().Be(MethodBase.GetCurrentMethod());
		}

		[Test]
		public void When_GetCallingMethod_is_called_Then_this_method_is_returned()
		{
			// ReSharper disable once ConvertClosureToMethodGroup
			// if we convert this to a MethodGroup, then the System.RuntimeMethodHandle.InvokeMethod is the calling method
			Func<MethodBase> fn = () => CallStack.GetCallingMethod();

			fn().Should().Be(MethodBase.GetCurrentMethod());
		}

		[Test]
		public void When_GetConstructingMethod_is_called_Then_throws_exception()
		{
			Action fn = () => CallStack.GetConstructingMethod();

			fn.ShouldThrow<ArgumentException>();
		}

		[Test]
		public void When_type_that_calls_GetConstructingMethod_is_created_Then_this_method_is_returned()
		{
			var obj = new CallsGetConstructingMethodInConstructor();

			obj.ConstructingMethod.Should().Be(MethodBase.GetCurrentMethod());
		}

		[Test]
		public void When_type_that_inherits_from_type_that_calls_GetConstructingMethod_is_created_Then_this_method_is_returned()
		{
			var obj = new InheritsFromCallsGetConstructingMethodInConstructor();

			obj.ConstructingMethod.Should().Be(MethodBase.GetCurrentMethod());
		}
	}
}

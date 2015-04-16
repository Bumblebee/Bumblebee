using System;

using Bumblebee.Exceptions;
using Bumblebee.Extensions;
using Bumblebee.Interfaces;

using FluentAssertions;

using NSubstitute;

using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Bumblebee.Extensions
{
	// ReSharper disable InconsistentNaming

	[TestFixture]
	public class VerificationTests
	{
		[TestCase(null, "Unable to verify.")]
		[TestCase("", "Unable to verify.")]
		[TestCase("Last name should equal 'Barson'.", "Unable to verify.  Last name should equal 'Barson'.")]
		public void given_value_and_verification_and_predicate_that_fails_when_verifying_should_throw_exception_with_verification_message(string verification, string verificationMessage)
		{
			var value = new { FirstName = "Todd", LastName = "Meinershagen" };

			Action action = () => value.Verify(verification, x => x.LastName == "Barson");

			action.ShouldThrow<VerificationException>().WithMessage(verificationMessage);
		}

		[Test]
		public void given_value_and_verification_and_predicate_that_succeeds_when_verifying_should_return_original_value()
		{
			var value = new { FirstName = "Todd", LastName = "Meinershagen" };

			var result = value.Verify("last name equals 'Meinershagen'", x => x.LastName == "Meinershagen");

			result.Should().Be(value);
		}

		[Test]
		public void given_value_and_predicate_that_fails_when_verifying_should_throw_exception_with_standard_message()
		{
			var value = new { FirstName = "Todd", LastName = "Meinershagen" };

			Action action = () => value.Verify(x => x.LastName.Equals("Barson"));

			action
				.ShouldThrow<VerificationException>()
				.WithMessage("Unable to verify.  Expected x.LastName.Equals(\"Barson\")");
		}

		[Test]
		public void given_value_and_predicate_that_succeeds_when_verifying_should_return_original_value()
		{
			var value = new { FirstName = "Todd", LastName = "Meinershagen" };

			var result = value.Verify(x => x.LastName == "Meinershagen");

			result.Should().Be(value);
		}

		[Test]
		public void given_assertion_that_fails_should_throw()
		{
			var value = new { };
			const string expectedMessage = "This is the message.";
			Action assertion = () =>
			{
				throw new AssertionException(expectedMessage);
			};

			Action action = () => value.VerifyThat(v => assertion());

			action
				.ShouldThrow<VerificationException>()
				.WithMessage(string.Format("Unable to verify.  {0}", expectedMessage))
				.WithInnerException<AssertionException>()
				.WithInnerMessage(expectedMessage);
		}

		[Test]
		public void given_assertion_that_does_not_fail_should_return_original_value()
		{
			var message = new { Name = "Todd" };
			var result = message.VerifyThat(m => m.Name.Should().Be("Todd"));

			result.Should().Be(message);
		}

		[TestCase(true)]
		[TestCase(false)]
		public void given_selection_verification_passes_when_verifying_selected_should_return_element(bool expected)
		{
			var element = Substitute.For<ISelectable>();
			element.Selected.Returns(expected);

			var result = element.VerifySelected(expected);
			result.Should().Be(element);
		}

		[TestCase(true)]
		[TestCase(false)]
		public void given_selection_verification_fails_when_verifying_selected_should_throw_exception(bool expected)
		{
			var element = Substitute.For<ISelectable>();
			element.Selected.Returns(!expected);

			Action action = () => element.VerifySelected(expected);
			action
				.ShouldThrow<VerificationException>()
				.WithMessage("Selection verification failed. Expected: {0}, Actual: {1}.".FormatWith(expected, element.Selected));
		}
	}
}

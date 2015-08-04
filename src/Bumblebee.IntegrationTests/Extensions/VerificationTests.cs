using System;
using System.IO;
using System.Reflection;

using Bumblebee.Exceptions;
using Bumblebee.Extensions;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using FluentAssertions;

using NSubstitute;

using NUnit.Framework;

using OpenQA.Selenium;

// ReSharper disable InconsistentNaming

namespace Bumblebee.IntegrationTests.Extensions
{
	[TestFixture]
	public class VerificationTests
	{
		[TestCase(null, "Unable to verify.")]
		[TestCase("", "Unable to verify.")]
		[TestCase("Last name should equal 'Barson'.", "Unable to verify.  Last name should equal 'Barson'.")]
		public void Given_value_and_verification_and_predicate_that_fails_when_verifying_should_throw_exception_with_verification_message(string verification, string verificationMessage)
		{
			var value = new { FirstName = "Todd", LastName = "Meinershagen" };

			Action action = () => value.Verify(verification, x => x.LastName == "Barson");

			action.ShouldThrow<VerificationException>().WithMessage(verificationMessage);
		}

		[Test]
		public void Given_value_and_verification_and_predicate_that_succeeds_when_verifying_should_return_original_value()
		{
			var value = new { FirstName = "Todd", LastName = "Meinershagen" };

			var result = value.Verify("last name equals 'Meinershagen'", x => x.LastName == "Meinershagen");

			result.Should().Be(value);
		}

		[Test]
		public void Given_value_and_predicate_that_fails_when_verifying_should_throw_exception_with_standard_message()
		{
			var value = new { FirstName = "Todd", LastName = "Meinershagen" };

			Action action = () => value.Verify(x => x.LastName.Equals("Barson"));

			action
				.ShouldThrow<VerificationException>()
				.WithMessage("Unable to verify.  Expected x.LastName.Equals(\"Barson\")");
		}

		[Test]
		public void Given_value_and_predicate_that_succeeds_when_verifying_should_return_original_value()
		{
			var value = new { FirstName = "Todd", LastName = "Meinershagen" };

			var result = value.Verify(x => x.LastName == "Meinershagen");

			result.Should().Be(value);
		}

		[Test]
		public void Given_assertion_that_fails_should_throw()
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
		public void Given_assertion_that_does_not_fail_should_return_original_value()
		{
			var message = new { Name = "Todd" };
			var result = message.VerifyThat(m => m.Name.Should().Be("Todd"));

			result.Should().Be(message);
		}

		[TestCase(true)]
		[TestCase(false)]
		public void Given_selection_verification_passes_when_verifying_selected_should_return_element(bool expected)
		{
			var element = Substitute.For<ISelectable>();
			element.Selected.Returns(expected);

			var result = element.VerifySelected(expected);
			result.Should().Be(element);
		}

		[TestCase(true)]
		[TestCase(false)]
		public void Given_selection_verification_fails_when_verifying_selected_should_throw_exception(bool expected)
		{
			var element = Substitute.For<ISelectable>();
			element.Selected.Returns(!expected);

			Action action = () => element.VerifySelected(expected);

			action
				.ShouldThrow<VerificationException>()
				.WithMessage(String.Format("Selection verification failed. Expected: {0}, Actual: {1}.", expected, element.Selected));
		}

		[Test]
		public void Given_verification_on_IClickable_and_take_screenshot_is_true_When_verification_fails_Then_screenshot_is_taken()
		{
			var driver = Substitute.For<IWebDriver>();
			var driverEnvironment = Substitute.For<IDriverEnvironment>();
			var settings = Substitute.For<ISettings>();
			var session = Substitute.For<Session>(driverEnvironment);

			var clickable = new TestClickable
			{
				Session = session,
				Text = "Not the right text"
			};

			driverEnvironment.CreateWebDriver().Returns(driver);

			settings.CaptureScreenOnVerificationFailure.Returns(true);

			session.Settings.Returns(settings);

			try
			{
				clickable.Verify(x => x.Text == "The right text");
			}
			catch (VerificationException)
			{
			}

			session.Received().CaptureScreen(Path.Combine(Environment.CurrentDirectory, String.Format("{0}.png", MethodBase.GetCurrentMethod().GetFullName())));

			session.End();
		}

		[Test]
		public void Given_verification_on_IClickable_and_take_screenshot_is_true_When_verification_succeeds_Then_screenshot_is_not_taken()
		{
			var driver = Substitute.For<IWebDriver>();
			var driverEnvironment = Substitute.For<IDriverEnvironment>();
			var settings = Substitute.For<ISettings>();
			var session = Substitute.For<Session>(driverEnvironment);

			driverEnvironment.CreateWebDriver().Returns(driver);

			settings.CaptureScreenOnVerificationFailure.Returns(true);

			session.Settings.Returns(settings);

			var clickable = new TestClickable
			{
				Session = session,
				Text = "The right text"
			};

			clickable.Verify(x => x.Text == "The right text");

			session.DidNotReceiveWithAnyArgs().CaptureScreen();

			session.End();
		}

		[Test]
		public void Given_verification_on_IClickable_and_take_screenshot_is_false_When_verification_fails_Then_screenshot_is_not_taken()
		{
			var driver = Substitute.For<IWebDriver>();
			var driverEnvironment = Substitute.For<IDriverEnvironment>();
			var settings = Substitute.For<ISettings>();
			var session = Substitute.For<Session>(driverEnvironment);

			driverEnvironment.CreateWebDriver().Returns(driver);

			settings.CaptureScreenOnVerificationFailure.Returns(false);

			session.Settings.Returns(settings);

			var clickable = new TestClickable
			{
				Session = session,
				Text = "Not the right text"
			};

			try
			{
				clickable.Verify(x => x.Text == "The right text");
			}
			catch (VerificationException)
			{
			}

			session.DidNotReceive().CaptureScreen(Path.Combine(Environment.CurrentDirectory, String.Format("{0}.png", MethodBase.GetCurrentMethod().GetFullName())));

			session.DidNotReceiveWithAnyArgs().CaptureScreen();

			session.End();
		}

		[Test]
		public void Given_verification_on_IClickable_and_take_screenshot_is_false_When_verification_succeeds_Then_screenshot_is_not_taken()
		{
			var driver = Substitute.For<IWebDriver>();
			var driverEnvironment = Substitute.For<IDriverEnvironment>();
			var settings = Substitute.For<ISettings>();
			var session = Substitute.For<Session>(driverEnvironment);

			driverEnvironment.CreateWebDriver().Returns(driver);

			settings.CaptureScreenOnVerificationFailure.Returns(false);

			session.Settings.Returns(settings);

			var clickable = new TestClickable
			{
				Session = session,
				Text = "The right text"
			};

			clickable.Verify(x => x.Text == "The right text");

			session.DidNotReceiveWithAnyArgs().CaptureScreen();

			session.End();
		}
	}

	public class TestClickable : IClickable
	{
		public IWebElement Tag { get; set; }
		public Session Session { get; set; }
		public string Text { get; set; }

		public TResult Click<TResult>() where TResult : IBlock
		{
			throw new NotImplementedException();
		}

		public IPerformsDragAndDrop GetDragAndDropPerformer()
		{
			throw new NotImplementedException();
		}
	}
}

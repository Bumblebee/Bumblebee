using System;
using Bumblebee.Exceptions;
using Bumblebee.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace Bumblebee.IntegrationTests.Extensions
{
    [TestFixture]
    public class VerificationTests
    {
        [Test]
        public void given_value_and_verification_and_predicate_that_fails_when_verifying_should_throw_exception_with_verification_message()
        {
            var value = new { FirstName = "Todd", LastName = "Meinershagen" };

            Action action = () => value.Verify("last name.", x => x.LastName == "Barson");

            action.ShouldThrow<VerificationException>().WithMessage("Unable to verify last name.");
        }

        [Test]
        public void given_value_and_predicate_that_fails_when_verifying_should_throw_exception_with_standard_message()
        {
            var value = new { FirstName = "Todd", LastName = "Meinershagen" };

            Action action = () => value.Verify(x => x.LastName == "Barson");

            action.ShouldThrow<VerificationException>().WithMessage("Unable to verify custom verification.");
        }

        [Test]
        public void given_value_and_verification_and_predicate_that_succeeds_when_verifying_should_not_throw_exception()
        {
            var value = new { FirstName = "Todd", LastName = "Meinershagen" };

            Action action = () => value.Verify("last name", x => x.LastName == "Meinershagen");

            action.ShouldNotThrow();
        }

        [Test]
        public void given_value_and_predicate_that_succeeds_when_verifying_should_not_throw_exception()
        {
            var value = new { FirstName = "Todd", LastName = "Meinershagen" };

            Action action = () => value.Verify(x => x.LastName == "Meinershagen");

            action.ShouldNotThrow();
        }

        [Test]
        public void given_assertion_that_does_not_fail_should_return_original_value()
        {
            var message = new { Name = "Todd" };
            var result = message.VerifyThat(m => m.Name.Should().Be("Todd"));

            result.Should().Be(message);
        }

        [Test]
        public void given_assertion_that_fails_should_throw()
        {
            var value = new {};
            const string expectedMessage = "This is the message.";
            Action assertion = () =>
            {
                throw new AssertionException(expectedMessage);
            };
            
            Action action = () => value.VerifyThat(v => assertion());

            action
                .ShouldThrow<VerificationException>()
                .WithMessage(string.Format("Unable to verify.\r\n{0}", expectedMessage))
                .WithInnerException<AssertionException>()
                .WithInnerMessage(expectedMessage);
        }
    }
}

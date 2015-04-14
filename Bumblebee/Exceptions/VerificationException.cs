using System;

namespace Bumblebee.Exceptions
{
	/// <summary>
	/// The exception that is thrown when a verification fails.
	/// </summary>
	public class VerificationException
		: Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="VerificationException"/> class.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public VerificationException(string message) : base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="VerificationException"/> class.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
		public VerificationException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}

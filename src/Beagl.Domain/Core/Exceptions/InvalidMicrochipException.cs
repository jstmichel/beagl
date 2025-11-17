using System;

namespace Beagl.Domain.Core.Exceptions
{
	/// <summary>
	/// Exception thrown when an invalid microchip value is provided.
	/// </summary>
	public sealed class InvalidMicrochipException : DomainException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidMicrochipException"/> class.
		/// </summary>
		public InvalidMicrochipException()
			: base()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidMicrochipException"/> class with a specified error code and message.
		/// </summary>
		public InvalidMicrochipException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidMicrochipException"/> class with a specified error code, message, and inner exception.
		/// </summary>
		public InvalidMicrochipException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

        /// <summary>
        /// Throws an <see cref="InvalidMicrochipException"/> if the provided value is null or empty.
        /// </summary>
        /// <param name="value">The microchip value to validate.</param>
        /// <param name="paramName">The name of the parameter being validated.</param>
        /// <exception cref="InvalidMicrochipException">Thrown when the value is null or empty.</exception>
        public static void ThrowIfNullOrEmpty(string? value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidMicrochipException($"Parameter '{paramName}' cannot be null or empty.");
            }
        }
	}
}

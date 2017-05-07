using System;

namespace Apopad.Common
{
    /// <summary>
    /// Represents errors that occur in the application.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ApopadException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApopadException"/> class.
        /// </summary>
        public ApopadException()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApopadException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ApopadException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApopadException"/> class.
        /// </summary>
        /// <param name="format">The format of the error message.</param>
        /// <param name="args">The arguments to be used for constructing the error message.</param>
        public ApopadException(string format, params object[] args)
            : base(string.Format(format, args))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApopadException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ApopadException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

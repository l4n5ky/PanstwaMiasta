using System;

namespace Passenger.Core.Exceptions
{
    public abstract class ApplicationException : Exception
    {
        public string Code { get; }

        protected ApplicationException()
        {
        }

        protected ApplicationException(string code)
        {
            Code = code;
        }

        protected ApplicationException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        protected ApplicationException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        protected ApplicationException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        protected ApplicationException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
using System;
using System.Runtime.Serialization;

namespace LearnWords.Exceptions.Authentication
{
    [Serializable]
    public class CookieDecryptException : System.Exception
    {
        public CookieDecryptException()
        {
        }

        public CookieDecryptException(string message) : base(message)
        {
        }

        public CookieDecryptException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected CookieDecryptException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
using System;
using System.Runtime.Serialization;

namespace LearnWords.Exceptions.Authentication
{
    [Serializable]
    public class UserNotFoundException : AuthenticationException
    {
        public UserNotFoundException()
        {
        }

        public UserNotFoundException(string message) : base(message)
        {
        }

        public UserNotFoundException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected UserNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
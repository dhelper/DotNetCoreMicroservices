using System;
using System.Runtime.Serialization;

namespace LunchService
{
    public class LunchAlreadyExistException : Exception
    {
        public LunchAlreadyExistException()
        {
        }

        public LunchAlreadyExistException(string message) : base(message)
        {
        }

        public LunchAlreadyExistException(string message, Exception inner) : base(message, inner)
        {
        }

        protected LunchAlreadyExistException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
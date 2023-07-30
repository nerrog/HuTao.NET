using System.Runtime.Serialization;

namespace HuTao.NET.Util
{
    public class Errors
    {
        public class AccountNotFoundException : Exception
        {
            public AccountNotFoundException() : base() { }
            public AccountNotFoundException(string message) : base(message) { }
            public AccountNotFoundException(string message, Exception innerException) : base(message, innerException) { }
            protected AccountNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        }

        public class HoyoLabAPIBadRequestException : Exception
        {
            private int retcode;
            public HoyoLabAPIBadRequestException() : base() { }
            public HoyoLabAPIBadRequestException(string message, int retcode) : base(message)
            {
                this.retcode = retcode;
            }

            public HoyoLabAPIBadRequestException(string message, Exception innerException) : base(message, innerException) { }
            protected HoyoLabAPIBadRequestException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        }

        public class HoyoLabCaptchaBlockException : Exception
        {
            public HoyoLabCaptchaBlockException() : base() { }

            public HoyoLabCaptchaBlockException(string message, Exception innerException) : base(message, innerException) { }
            protected HoyoLabCaptchaBlockException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        }
    }
}

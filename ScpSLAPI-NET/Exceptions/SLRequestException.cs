namespace ScpSLAPI_NET.Exceptions
{
    public class SLRequestException : AggregateException
    {
        public SLRequestException() 
        { 
        }

        public SLRequestException(string message) : base(message)
        {
        }

        public SLRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

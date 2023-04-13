namespace ScpSLAPI_NET.Exceptions
{
    public class SLRequestJsonException : SLRequestException
    {
        public SLRequestJsonException()
        {
        }

        public SLRequestJsonException(string message) : base(message)
        {
        }

        public SLRequestJsonException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

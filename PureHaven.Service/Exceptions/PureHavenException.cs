namespace PureHaven.Service.Exceptions;
public class PureHavenException : Exception
{
    public int StatusCode { get; set; }

    public PureHavenException(int code, string message) : base(message)
    {
        StatusCode = code;
    }
}

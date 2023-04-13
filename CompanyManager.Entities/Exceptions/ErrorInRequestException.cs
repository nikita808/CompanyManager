namespace CompanyManager.Entities.Exceptions;

public class ErrorInRequestException : Exception
{
    public ErrorInRequestException(string? message) : base($"Error in request: {message}")
    {
    }
}
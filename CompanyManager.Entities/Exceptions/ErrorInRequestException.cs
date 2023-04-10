namespace CompanyManager.Entities.Exceptions;

public class ErrorInRequestException : BadRequestException
{
    public ErrorInRequestException(string? message) : base($"Error in request: {message}")
    {
    }
}
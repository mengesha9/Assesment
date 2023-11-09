namespace Assesment.Application.Common.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string name, object key)
        : base($"{name} ({key}) was not found")
    {
    }
}
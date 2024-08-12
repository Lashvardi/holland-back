namespace doit.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
    }
}

// already exist exception
public class AlreadyExistException : Exception
{
    public AlreadyExistException(string message) : base(message)
    {
    }
}

// invalid credentials exception
public class InvalidCredentialsException : Exception
{
    public InvalidCredentialsException(string message) : base(message)
    {
    }
}

namespace EventSphere.Core.Primitives;

public class Result<T>
{
    private readonly T? _value;

    private Result(T value)
    {
        Value = value;
        IsSuccess = true;
        Error = CustomError.None;
    }

    private Result(CustomError error)
    {
        if (error == CustomError.None)
        {
            throw new ArgumentException("invalid error", nameof(error));
        }

        IsSuccess = false;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public T Value 
    { 
        get
        {
            if (IsFailure)
            {
                throw new InvalidOperationException("there is no value for failure");
            }

            return _value;
        }

        private init => _value = value;
    }
    public CustomError Error { get; }
    public static Result<T> Success(T value) => new(value);
    public static Result<T> Failure(CustomError error) => new(error);
}
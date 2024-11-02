namespace EventSphere.Core;

public sealed record CustomError(string Code, string Description)
{
    public static readonly CustomError None = new(string.Empty, string.Empty);
}

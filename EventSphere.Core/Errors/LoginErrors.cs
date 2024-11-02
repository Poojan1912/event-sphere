namespace EventSphere.Core.Errors;

public static class LoginErrors
{
    public static readonly CustomError InvalidCredentials = new("Login.InvalidCredentials", "Email address or Password is not correct!");
}

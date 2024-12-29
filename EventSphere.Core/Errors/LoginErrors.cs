using EventSphere.Core.Enums;

namespace EventSphere.Core.Errors;

public static class LoginErrors
{
    public static readonly CustomError invalidCredentials = new("Login.InvalidCredentials", "Email address or Password is not correct!", ErrorType.Unauthorized);
    public static readonly CustomError userNotFound = new("Login.UserNotFound", "User not found!", ErrorType.Unauthorized);
    public static readonly CustomError userEmailNotFound = new("Login.UserEmailNotFound", "User email not found!", ErrorType.Unauthorized);
}

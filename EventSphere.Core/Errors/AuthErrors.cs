using EventSphere.Core.Enums;

namespace EventSphere.Core.Errors;

public static class AuthErrors
{
    public static readonly CustomError jwtSecretNotFound = new("Auth.SecretNotFound", "JWT Secret not found!", ErrorType.InternalServerError);
}



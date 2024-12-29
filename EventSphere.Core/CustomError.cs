using EventSphere.Core.Enums;

namespace EventSphere.Core;

public sealed record CustomError(string Code, string Description, ErrorType ErrorType) { }

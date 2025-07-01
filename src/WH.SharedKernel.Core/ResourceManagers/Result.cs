using System.Collections.Generic;
using System.Linq;

namespace WH.SharedKernel.ResourceManagers;

public record Result
{
    public bool Success => !Errors.Any();
    public object? Data { get; set; }
    public IEnumerable<Error> Errors { get; set; } = new List<Error>();

    public static Result CreateResponseWithData(object? data = null)
    {
        return new Result { Data = data };
    }

    public static Result CreateResponseWithErrors(IEnumerable<Error> errors)
    {
        return new Result { Errors = errors };
    }
}

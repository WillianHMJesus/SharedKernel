namespace WH.SharedKernel.ResourceManagers;

public record Error
{
    public Error(string key, string message)
    {
        Key = key;
        Message = message;
    }

    public string Key { get; private set; }
    public string Message { get; private set; }
};

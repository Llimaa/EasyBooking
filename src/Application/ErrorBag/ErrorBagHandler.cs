using EasyBooking.Domain;

namespace EasyBooking.Appplication;

public class ErrorBagService : IErrorBagService
{
    private readonly Dictionary<string, string> _errors;

    public ErrorBagService()
    {
        _errors = new();
    }

    public void HandlerError(Dictionary<string, string> errors)
    {
        foreach(var error in errors) 
            _errors.Add(error.Key, error.Value);
    }

    public void HandlerError(string code, string error) =>
        _errors.TryAdd(code, error);

    public bool HasError() =>
        _errors.Count > 0;

    public Dictionary<string, string> Raise() => _errors;
}
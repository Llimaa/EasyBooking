namespace EasyBooking.Domain;

public interface IErrorBagService 
{
    void HandlerError(Dictionary<string, string> errors);
    void HandlerError(string code, string error);
    bool HasError();
    Dictionary<string, string> Raise();
}

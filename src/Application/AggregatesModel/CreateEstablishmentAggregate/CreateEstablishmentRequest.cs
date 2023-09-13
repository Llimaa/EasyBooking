using FluentValidation;

namespace EasyBooking.Appplication;

public record CreateEstablishmentRequest 
{
    public string PhoneNumber {get; set;} = null!;
    public string Name {get; set;} = null!;
    public string Description {get; set;} = null!;
    public string Neighborhood {get; set;} = null!;
    public string Street {get; set;} = null!;
    public string Number {get; set;} = null!;
    public string Zipcode {get; set;} = null!;


    public (Dictionary<string, string>, bool) Validate(IValidator<CreateEstablishmentRequest> specification) 
    {
        var (errors, valid) = specification.Validate(this);
        return(errors.AsDefaultFormat(), valid);
    }
}

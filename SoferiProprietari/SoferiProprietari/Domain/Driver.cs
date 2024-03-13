namespace SoferiProprietari.Domain;

public class Driver : Person
{
    public LicenseCategory LicenseCat { get; set; }
    
    public DateOnly ExpirationDate { get; set; }

    public override string ToString()
    {
        return base.ToString() + " " + LicenseCat + " " + ExpirationDate;
    }
}
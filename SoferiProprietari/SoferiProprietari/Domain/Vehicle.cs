namespace SoferiProprietari.Domain;

public class Vehicle : IHadID<string>
{
    public string Id { get; set; }

    public LicenseCategory LicenseCat { get; set; }
    
    public int FabricationYear { get; set; }

    public string Owner { get; set; }

    public override string ToString()
    {
        return Id + " " + LicenseCat + " " + FabricationYear + " " + Owner;
    }
}
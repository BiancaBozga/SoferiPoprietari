namespace SoferiProprietari.Domain;

class LineToEntityMapping
{
    public static Person CreatePerson(string line)
    {
        string[] fields = line.Split(','); 
        return new Person()
        {
            Id = fields[0],
            Name = fields[1],
            Age = Double.Parse(fields[2])
        };
    }
    
    public static Vehicle CreateVehicle(string line)
    {
        string[] fields = line.Split(','); 
        return new Vehicle()
        {
            Id = fields[0],
            FabricationYear = Int32.Parse(fields[1]),
            LicenseCat = (LicenseCategory)Enum.Parse(typeof(LicenseCategory), fields[2]),
            Owner = fields[3]
        };
    }
}
namespace SoferiProprietari.Domain;

public class Person : IHadID<string>
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public double Age { get; set; }
    
    public List<Vehicle> Vehicles { get; set; }

    public override string ToString()
    {
        return Id + " " + Name + " " + Age + " " + Vehicles;
    }
}
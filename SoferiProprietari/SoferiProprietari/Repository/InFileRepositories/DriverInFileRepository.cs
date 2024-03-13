using SoferiProprietari.Domain;
using SoferiProprietari.Repository.utils;

namespace SoferiProprietari.Repository.InFileRepositories;

public class DriverInFileRepository : InFileRepository<string, Driver>
{
    private string peopleFileName;
    private string vehiclesFileName;
    public DriverInFileRepository(string fileName, string peopleFileName, string vehiclesFileName) : base(fileName, null)
    {
        this.peopleFileName = peopleFileName;
        this.vehiclesFileName = vehiclesFileName;
        loadFromFile();
    }
    
    private new void loadFromFile()
    {
        List<Vehicle> vehicles = DataReader.ReadData(vehiclesFileName, LineToEntityMapping.CreateVehicle);
        List<Person> people = DataReader.ReadData(peopleFileName, LineToEntityMapping.CreatePerson);
        
        using (StreamReader sr = new StreamReader(fileName))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] fields = line.Split(',');

                Person person = people.Find(x => x.Id.Equals(fields[0]));
                person.Vehicles = vehicles.FindAll(x => x.Owner.Equals(person.Id));
                
                Driver driver = new Driver()
                {
                    Id = fields[0],
                    Name = person.Name,
                    Age = person.Age,
                    Vehicles = person.Vehicles,
                    LicenseCat = (LicenseCategory)Enum.Parse(typeof(LicenseCategory), fields[1]),
                    ExpirationDate = DateOnly.Parse(fields[2])
                };

                base._dictionary[driver.Id] = driver;
            }
        }
    }
    
}
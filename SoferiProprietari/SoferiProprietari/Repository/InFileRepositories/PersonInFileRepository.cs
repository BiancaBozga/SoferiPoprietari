using SoferiProprietari.Domain;
using SoferiProprietari.Repository.utils;

namespace SoferiProprietari.Repository.InFileRepositories;

public class PersonInFileRepository: InFileRepository<string, Person>
{
    private string vehiclesFileName;
    public PersonInFileRepository(string fileName, string vehiclesFileName) : base(fileName, null)
    {
        this.vehiclesFileName = vehiclesFileName;
        loadFromFile();
    }

    private new void loadFromFile()
    {
        List<Vehicle> vehicles = DataReader.ReadData(vehiclesFileName, LineToEntityMapping.CreateVehicle);

        using (StreamReader sr = new StreamReader(fileName))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] fields = line.Split(',');
                List<Vehicle> owned = vehicles.FindAll(x => x.Owner.Equals(fields[0]));

                Person person = new Person()
                {
                    Id = fields[0],
                    Name = fields[1],
                    Age = Int32.Parse(fields[2]),
                    Vehicles = owned
                };

                base._dictionary[person.Id] = person;
            }
        }
    }
}
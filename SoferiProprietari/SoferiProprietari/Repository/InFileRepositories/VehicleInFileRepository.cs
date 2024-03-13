using SoferiProprietari.Domain;

namespace SoferiProprietari.Repository.FileRepos;

public class VehicleInFileRepository : InFileRepository<string, Vehicle>
{
    public VehicleInFileRepository(string fileName) : base(fileName, LineToEntityMapping.CreateVehicle)
    {
        
    }
}
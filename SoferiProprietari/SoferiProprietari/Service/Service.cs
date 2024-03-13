using SoferiProprietari.Domain;
using SoferiProprietari.Repository;

namespace SoferiProprietari.Service;

public class Service
{
    private IRepository<string, Person> personRepo;
    private IRepository<string, Driver> driverRepo;
    private IRepository<string, Vehicle> vehicleRepo;

    public Service(IRepository<string, Person> personRepo, IRepository<string, Driver> driverRepo, IRepository<string, Vehicle> vehicleRepo)
    {
        this.personRepo = personRepo;
        this.driverRepo = driverRepo;
        this.vehicleRepo = vehicleRepo;
    }

    public List<String> PeopleDescByName()
    {
        return 
            (from person in personRepo.FindAll()
            orderby person.Name
            select person.Name + " " + person.Age)
            .ToList();

    }
    
    public List<string> DriversWhoDontOwn()
    {
        return
            (from driver in driverRepo.FindAll()
            where driver.Vehicles.Count == 0
            select driver.Name + " " + driver.Age)
            .ToList();
    }
    
    public List<string> VehiclesWithDriverOwnersWrongCat()
    {
        return
            (from vehicle in vehicleRepo.FindAll()
                where (from driver in driverRepo.FindAll()
                        where driver.Id == vehicle.Owner && driver.LicenseCat != vehicle.LicenseCat
                        select driver)
                    .ToList().Count != 0
                select vehicle.ToString())
            .ToList();
    }
    public List<string> DriversWithExpiredLicensesIn2019()
    {
        int ExpYear = 2019;

        return (from driver in driverRepo.FindAll()
            where driver.ExpirationDate.Year == ExpYear
            select driver.Name + " "+ driver.LicenseCat).ToList();
    }
    public List<string> PersonsButNotDrivers()
    {
        return ( from person in personRepo.FindAll()
            where person.Vehicles.Any() && !driverRepo.FindAll().Any(sofer => sofer.Id == person.Id)
            select person.Name+" "+ person.Age).ToList();
    }


}
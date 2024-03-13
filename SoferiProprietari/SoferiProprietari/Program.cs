// See https://aka.ms/new-console-template for more information

using SoferiProprietari.Domain;
using SoferiProprietari.Repository;
using SoferiProprietari.Repository.FileRepos;
using SoferiProprietari.Repository.InFileRepositories;
using SoferiProprietari.Service;
using SoferiProprietari.UI;

IRepository<string, Person> repo_people = new PersonInFileRepository("C:\\Users\\computer\\Downloads\\SoferiProprietari\\SoferiProprietari\\SoferiProprietari\\people.txt", "C:\\Users\\computer\\Downloads\\SoferiProprietari\\SoferiProprietari\\SoferiProprietari\\vehicles.txt");
IRepository<string, Driver> repo_drivers = new DriverInFileRepository("C:\\Users\\computer\\Downloads\\SoferiProprietari\\SoferiProprietari\\SoferiProprietari\\drivers.txt", "C:\\Users\\computer\\Downloads\\SoferiProprietari\\SoferiProprietari\\SoferiProprietari\\people.txt", "C:\\Users\\computer\\Downloads\\SoferiProprietari\\SoferiProprietari\\SoferiProprietari\\vehicles.txt");
IRepository<string, Vehicle> repo_vehicles = new VehicleInFileRepository("C:\\Users\\computer\\Downloads\\SoferiProprietari\\SoferiProprietari\\SoferiProprietari\\vehicles.txt");

/*foreach (var person in repo_people.FindAll())
{
    Console.WriteLine(person);
}

foreach (var person in repo_drivers.FindAll())
{
    Console.WriteLine(person);
}

foreach (var person in repo_vehicles.FindAll())
{
    Console.WriteLine(person);
}*/

Service serv = new Service(repo_people, repo_drivers, repo_vehicles);

/*foreach (var s in serv.PeopleDescByName())
{
    Console.WriteLine(s);
}

Console.WriteLine();
foreach (var s in serv.DriversWhoDontOwn())
{
    Console.WriteLine(s);
}

Console.WriteLine();
foreach (var s in serv.VehiclesWithDriverOwnersWrongCat())
{
    Console.WriteLine(s);
}*/


UI ui = new UI(serv);

ui.Run();
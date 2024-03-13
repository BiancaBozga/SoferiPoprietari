namespace SoferiProprietari.UI;

public class UI
{
    private Service.Service service;

    public UI(Service.Service service)
    {
        this.service = service;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Exercise number:");
            int cmd = Int32.Parse(Console.ReadLine());

            switch (cmd)
            {
                case 1:
                    execute1();
                    break;
                case 2:
                    execute2();
                    break;
                case 3:
                    execute3();
                    break; 
                case 4:
                    execute4();
                    break;
                case 5:
                    execute5();
                    break;
                case 0:
                    return;
            }
        }
    }

    void execute1()
    {
        foreach (var s in service.PeopleDescByName())
        {
            Console.WriteLine(s);
        }
    }

    void execute2()
    {
        foreach (var s in service.DriversWithExpiredLicensesIn2019())
        {
            Console.WriteLine(s);
        }
    }
    
    void execute3()
    {
        foreach (var s in service.DriversWhoDontOwn())
        {
            Console.WriteLine(s);
        }
    }

    void execute4()
    {
        foreach (var p in service.PersonsButNotDrivers())
        {
            Console.WriteLine(p);
        }
    }
    void execute5()
    {
        foreach (var s in service.VehiclesWithDriverOwnersWrongCat())
        {
            Console.WriteLine(s);
        }
    }
}
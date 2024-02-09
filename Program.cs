//MIS 3033
//database manipulations
//Camille Duryea
//113529005

using a;

Console.WriteLine("DB");


//step 2
//step 3
//Microsoft.EntityFrameworkCore.Design
//Microsoft.EntityFrameworkCore.Tools
//Microsoft.EntityFrameworkCore.Sqlite

string menuStr = @" 
****************************************************
Option Menu
1. Add City
2. Show all cities
3. Search a city by name
4. Delete a city by ID
5. Search Cities in one state
6. Calculate total popuation
7. Find the city with largest population
Press other keys to exit
****************************************************
";
//Console.WriteLine(menuStr);

CityDB db;
db = new CityDB(); //datbase connection

while (true) //infinite loop
{
    Console.WriteLine(menuStr);
    Console.Write("Input an options: ");
    string optStr = (Console.ReadLine());

    if(optStr == "1")
    {
        //add new city
        Console.WriteLine("Add a new city");
        Console.WriteLine("Input the city ID: ");
        string idStr = Console.ReadLine();
        int id = Convert.ToInt32(idStr);

        Console.Write("Input city name: ");
        string cityName = Console.ReadLine();

        Console.Write("Input state name: ");
        string stateName = Console.ReadLine();

        Console.Write("Input population: ");
        string popStr = Console.ReadLine();
        int pop = Convert.ToInt32(popStr);

        Console.Write("Input Lat: ");
        string latStr = Console.ReadLine();
        double lat = Convert.ToDouble(latStr);

        Console.Write("Input Lon: ");
        string lonStr = Console.ReadLine();
        double lon = Convert.ToDouble(lonStr);  

        City city = new City();
        city.Id = id;
        city.CityName = cityName;
        city.State = stateName;
        city.population = pop;
        city.lat = lat;
        city.lon = lon;

        db.cities.Add(city); // memory RAM

        db.SaveChanges();
    }
    else if(optStr == "2")
    {
        // show all cities
        Console.WriteLine("All cities");
        List<City> cityList = db.cities.ToList();
        for (int i = 0; i < cityList.Count; i++)
        {
            Console.WriteLine(cityList[i]);
        }
    }
    else if(optStr == "3")
    {
        //search a city by name
        Console.WriteLine("Search a city by name");
        Console.Write("Input a city name: ");
        string cityName = Console.ReadLine();

        //only get one city
        List<City> cityList = db.cities.Where(x => x.CityName.ToLower()==cityName.ToLower()).ToList();

        for(int i = 0; i<cityList.Count; i++)
        {
            Console.WriteLine(cityList[i]);
        }
    }
    else if(optStr == "4")
    {
        //delete a city by ID
        Console.WriteLine("Delete city by ID:");
        Console.WriteLine("Input a city ID: ");
        string cityIdStr = Console.ReadLine();
        int cityId = Convert.ToInt32(cityIdStr);

        City city=db.cities.Where(x=>x.Id==cityId).FirstOrDefault();

        if(city == null)
        {
            Console.WriteLine("The city ID does not exist in this DB!");
        }
        else
        {
            db.cities.Remove(city); //remove city from RAM

            db.SaveChanges(); 
        }
    }
    else if(optStr == "5")
    {
        //search cities in one state
        Console.WriteLine("Search cities in one State");
        Console.Write("Input a state name: ");
        string stateNameStr = Console.ReadLine();

        List<City> cityList = db.cities.Where(x => x.State.ToLower() == stateNameStr.ToLower()).ToList();

        if(cityList.Count== 0)
        {
            Console.WriteLine($"No cities found in state {stateNameStr}!");
        }
        else
        {
            Console.WriteLine($"{cityList.Count} cities are found in state {stateNameStr}");

            for(int i = 0; i<cityList.Count; i++)
            {
                Console.WriteLine(cityList[i]);
            }
        }
    }
    else if (optStr == "6")
    {
        //calcuate total population
        Console.WriteLine("Sum of population");

        double sumPop = db.cities.Sum(x => x.population);

        Console.WriteLine($"Total population: {sumPop:F0}");
    }
    else if(optStr == "7")
    {
        // find city with largest population 
        Console.WriteLine("City with the largest population");
        City city = db.cities.ToList().MaxBy(x => x.population);

        Console.WriteLine(city);
    }
    else
    {
        Console.WriteLine("Thank you and goodbye!");
        break; // stop 
    }
}
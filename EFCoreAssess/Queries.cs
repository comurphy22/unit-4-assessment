using Microsoft.EntityFrameworkCore;

public class Queries
{
    /// Get the human with the primary key 2
    public static Human? Query1()
    {
        using var db = new AssessDbContext();
        return db.Humans.Find(2);
    }

    /// Get the first animal whose species is "fish"
    public static Animal? Query2()
    {
        using var db = new AssessDbContext();
        return db.Animals
            .OrderBy(a => a.AnimalId)
            .FirstOrDefault(a => a.Species == "fish");
    }

    /// Get all the animals who belong to the human with primary key 5
    public static List<Animal> Query3()
    {
        using var db = new AssessDbContext();
        return db.Animals
            .Where(a => a.HumanId == 5)
            .OrderBy(a => a.AnimalId)
            .ToList();
    }

    /// Get all animals born in a year greater than (but not equal to) 2015
    public static List<Animal> Query4()
    {
        using var db = new AssessDbContext();
        return db.Animals
            .Where(a => a.BirthYear > 2015)
            .OrderBy(a => a.AnimalId)
            .ToList();
    }

    /// Get all the humans with first names that start with "J"
    public static List<Human> Query5()
    {
        using var db = new AssessDbContext();
        return db.Humans
            .Where(h => h.FirstName.StartsWith("J"))
            .OrderBy(h => h.HumanId)
            .ToList();
    }

    /// Get all the animals who don't have a birth year
    public static List<Animal> Query6()
    {
        using var db = new AssessDbContext();
        return db.Animals
            .Where(a => a.BirthYear == null)
            .OrderBy(a => a.AnimalId)
            .ToList();
    }

    /// Get all the animals with species "fish" OR "rabbit"
    public static List<Animal> Query7()
    {
        using var db = new AssessDbContext();
        return db.Animals
            .Where(a => a.Species == "fish" || a.Species == "rabbit")
            .OrderBy(a => a.AnimalId)
            .ToList();
    }

    /// Get all the humans who don't have an email address that contains "gmail"
    public static List<Human> Query8()
    {
        using var db = new AssessDbContext();
        return db.Humans
            .Where(h => !h.Email.Contains("gmail"))
            .OrderBy(h => h.HumanId)
            .ToList();
    }

    /// Print a directory of humans and their animals
    public static void PrintHumansAndAnimals()
    {
        using var db = new AssessDbContext();
        var humans = db.Humans
            .Include(h => h.Animals.OrderBy(a => a.Name))
            .OrderBy(h => h.FirstName)
            .ThenBy(h => h.LastName)
            .ToList();

        foreach (var human in humans)
        {
            Console.WriteLine($"{human.FirstName} {human.LastName}");
            foreach (var animal in human.Animals)
            {
                Console.WriteLine($"- {animal.Name}, {animal.Species}");
            }
        }
    }

    /// Return a list of humans who have animals of a certain species
    public static List<Human> GetHumansByAnimalSpecies(string species)
    {
        using var db = new AssessDbContext();
        return db.Humans
            .Where(h => h.Animals.Any(a => a.Species == species))
            .ToList();
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

class Program
{
    public static Stopwatch globalTimer = new Stopwatch();
    public static long globalTimeLimit = 5000; // Total time limit for all tasks (ms)
    public static bool isDead = false;

    static void Main(string[] args)
    {
        globalTimer.Start();
        Console.WriteLine("The zombie apocalypse has begun. Your survival depends on your speed and efficiency!");

        // List of survival tasks
        var tasks = new List<SurvivalTask>
        {
            new SurvivalTask("Zombie Tracking", ZombieTracking, 1000),
            new SurvivalTask("Scavenging Supplies", ScavengingSupplies, 700),
            new SurvivalTask("Zombie Horde Defense", ZombieHordeDefense, 1200),
            new SurvivalTask("Base Defense Turret Targeting", BaseDefenseTurretTargeting, 800),
            new SurvivalTask("Escape Pathfinding", EscapePathfinding, 1000),
            new SurvivalTask("Crafting Weapons", CraftingWeapons, 900),
            new SurvivalTask("Searching for Survivors", SearchingForSurvivors, 1100),
            new SurvivalTask("Zombie Outbreak Prediction", ZombieOutbreakPrediction, 850),
            new SurvivalTask("Food Inventory Management", FoodInventoryManagement, 750)
        };

        // Execute tasks
        foreach (var task in tasks)
        {
            task.Run();
            if (isDead) break; // End simulation if the player dies

            // Check global timer
            if (globalTimer.ElapsedMilliseconds > globalTimeLimit)
            {
                Console.WriteLine("You took too long overall! As you hesitate, zombies overwhelm your defenses.");
                isDead = true;
                break;
            }
        }

        globalTimer.Stop();

        if (!isDead)
        {
            Console.WriteLine($"You survived! Total time: {globalTimer.ElapsedMilliseconds}ms");
        }
    }

    // 12072ms
    static void ZombieTracking()
    {
        Console.WriteLine("You cautiously track the movements of the zombies...");
        Thread.Sleep(500); // Dramatic pause for suspense

        // TASK REQUIREMENTS:
        // 1. Track the coordinates of 100,000 zombies on a 2D grid (0-9999 for x and y).
        // 2. Ensure no duplicate coordinates are added to the tracking list.
        // 3. Print messages when a new zombie is tracked or already tracked.

        List<(int x, int y)> zombieLocations = new List<(int, int)>();
        Random rnd = new Random();

        int totalZombies = 100000;
        for (int i = 0; i < totalZombies; i++)
        {
            int x = rnd.Next(0, 10000);
            int y = rnd.Next(0, 10000);

            bool isDuplicate = false;
            foreach (var loc in zombieLocations)
            {
                if (loc.x == x && loc.y == y)
                {
                    isDuplicate = true;
                    break;
                }
            }

            if (!isDuplicate)
            {
                zombieLocations.Add((x, y));
            }
        }
        Console.WriteLine("Zombie tracking complete. You prepare for the next task.");
    }
    // 528ms.
    //static void ZombieTracking()
    //{
    //    Console.WriteLine("You cautiously track the movements of the zombies...");
    //    Thread.Sleep(500); // Dramatic pause for suspense

    //    // TASK REQUIREMENTS:
    //    // 1. Track the coordinates of 100,000 zombies on a 2D grid (0-9999 for x and y).
    //    // 2. Ensure no duplicate coordinates are added to the tracking list.
    //    // 3. Print messages when a new zombie is tracked or already tracked.

    //    // Use Dictionary to track unique zombie locations
    //    Dictionary<(int x, int y), bool> zombieLocations = new Dictionary<(int, int), bool>();
    //    Random rnd = new Random();

    //    int totalZombies = 100000;
    //    for (int i = 0; i < totalZombies; i++)
    //    {
    //        int x = rnd.Next(0, 10000);
    //        int y = rnd.Next(0, 10000);

    //        if (!zombieLocations.ContainsKey((x, y))) // Check if the coordinate already exists
    //        {
    //            zombieLocations[(x, y)] = true; // Add new coordinate
    //        }
    //    }

    //    Console.WriteLine("Zombie tracking complete. You prepare for the next task.");
    //}




    static void ScavengingSupplies()
    {
        Console.WriteLine("You start to scavenge supplies...");
        Thread.Sleep(500); // Dramatic pause
        Console.WriteLine("You find some water.");
        Thread.Sleep(500);
        Console.WriteLine("You find some food.");
        Thread.Sleep(500);
        Console.WriteLine("You find...");
        Thread.Sleep(1000);
        Console.WriteLine("...a zombie!");
        Thread.Sleep(700);
        Console.WriteLine("You run pathetically slow and are eaten.");
        Program.isDead = true; // Trigger death
    }

    static void ZombieHordeDefense()
    {
        Console.WriteLine("You prepare to defend your base against the horde...");
        SimulateWork(1200);
        Console.WriteLine("The zombies are repelled, for now.");
    }

    static void BaseDefenseTurretTargeting()
    {
        Console.WriteLine("You frantically adjust the turret settings...");
        SimulateWork(800);
        Console.WriteLine("The turrets are operational, just in time.");
    }

    static void EscapePathfinding()
    {
        Console.WriteLine("You map out an escape route...");
        SimulateWork(1000);
        Console.WriteLine("The path is clear. You move quickly.");
    }

    static void CraftingWeapons()
    {
        Console.WriteLine("You gather materials to craft a weapon...");
        SimulateWork(900);
        Console.WriteLine("You craft a sturdy bat with nails. It's not perfect, but it works.");
    }

    static void SearchingForSurvivors()
    {
        Console.WriteLine("You search the ruins for survivors...");
        Thread.Sleep(500); // Dramatic pause
        Console.WriteLine("You hear a faint voice calling for help.");
        SimulateWork(600);
        Console.WriteLine("You rescue a survivor!");
    }

    static void ZombieOutbreakPrediction()
    {
        Console.WriteLine("You analyze the zombie outbreak patterns...");
        SimulateWork(850);
        Console.WriteLine("You predict the next outbreak location. Time to prepare.");
    }

    static void FoodInventoryManagement()
    {
        Console.WriteLine("You organize the food inventory...");
        SimulateWork(750);
        Console.WriteLine("The food is sorted. You avoid wasting precious supplies.");
    }

    // Helper method to simulate work
    static void SimulateWork(int delay)
    {
        Thread.Sleep(delay); // Simulate slow task
    }
}

// Class to represent a survival task
class SurvivalTask
{
    public string Name { get; }
    private Action Task { get; }
    private long TimeLimit { get; } // Time limit in milliseconds

    public SurvivalTask(string name, Action task, long timeLimit)
    {
        Name = name;
        Task = task;
        TimeLimit = timeLimit;
    }

    public void Run()
    {
        if (Program.isDead) return;

        Stopwatch sw = new Stopwatch();
        sw.Start();

        Console.WriteLine($"Starting task: {Name}");
        Task.Invoke(); // Run the task
        sw.Stop();

        if (sw.ElapsedMilliseconds > TimeLimit)
        {
            Console.WriteLine($"Task '{Name}' took too long ({sw.ElapsedMilliseconds}ms)! You failed to complete it in time.");
            DeathMessage(Name);
            Program.isDead = true;
        }
        else
        {
            Console.WriteLine($"Task '{Name}' completed in {sw.ElapsedMilliseconds}ms.");
        }
    }

    private void DeathMessage(string taskName)
    {
        Console.WriteLine($"While working on '{taskName}', the zombies caught up to you. You did not survive.");
    }
}

using Spectre.Console;

namespace Circus;

public class Program
{
    static List<Animal> Animals = new();
    static List<Wagon> Wagons = new();
    
    public static void Main()
    {
        AnsiConsole.Markup("Welcome to [underline red]Circus![/] \n");
        
        var amountSmallCarnivores = AnsiConsole.Prompt(
            new TextPrompt<int>("How many small carnivores would you like?")
                .ValidationErrorMessage("[red]That's not a valid number[/]"));
        
        var amountMediumCarnivores = AnsiConsole.Prompt(
            new TextPrompt<int>("How many medium carnivores would you like?")
                .ValidationErrorMessage("[red]That's not a valid number[/]"));
        
        var amountLargeCarnivores = AnsiConsole.Prompt(
            new TextPrompt<int>("How many large carnivores would you like?")
                .ValidationErrorMessage("[red]That's not a valid number[/]"));
        
        var amountSmallHerbivores = AnsiConsole.Prompt(
            new TextPrompt<int>("How many small herbivores would you like?")
                .ValidationErrorMessage("[red]That's not a valid number[/]"));
        
        var amountMediumHerbivores = AnsiConsole.Prompt(
            new TextPrompt<int>("How many medium herbivores would you like?")
                .ValidationErrorMessage("[red]That's not a valid number[/]"));
        
        var amountLargeHerbivores = AnsiConsole.Prompt(
            new TextPrompt<int>("How many large herbivores would you like?")
                .ValidationErrorMessage("[red]That's not a valid number[/]"));

        // int amountLargeCarnivores = 0;
        // int amountMediumCarnivores = 0;
        // int amountSmallCarnivores = 1;
        //
        // int amountSmallHerbivores = 1;
        // int amountMediumHerbivores = 1;
        // int amountLargeHerbivores = 2;
        
        for (int i = 0; i < amountSmallCarnivores; i++)
        {
            var animal = new Animal(diet.Carnivore, animalSize.small);
            Animals.Add(animal);
        }

        for (int i = 0; i < amountMediumCarnivores; i++)
        {
            var animal = new Animal(diet.Carnivore, animalSize.medium);
            Animals.Add(animal);
        }

        for (int i = 0; i < amountLargeCarnivores; i++)
        {
            var animal = new Animal(diet.Carnivore, animalSize.large);
            Animals.Add(animal);
        }

        for (int i = 0; i < amountSmallHerbivores; i++)
        {
            var animal = new Animal(diet.Herbivore, animalSize.small);
            Animals.Add(animal);
        }

        for (int i = 0; i < amountLargeHerbivores; i++)
        {
            var animal = new Animal(diet.Herbivore, animalSize.large);
            Animals.Add(animal);
        }
        
        for (int i = 0; i < amountMediumHerbivores; i++)
        {
            var animal = new Animal(diet.Herbivore, animalSize.medium);
            Animals.Add(animal);
        }
        
        foreach (Animal animal in Animals)
        {
            bool addedToExistingWagon = false;

            foreach (var wagon in Wagons)
            {
                if (wagon.CanAddAnimal(animal))
                {
                    wagon.AddAnimal(animal);
                    addedToExistingWagon = true;
                    break;
                }
            }

            if (!addedToExistingWagon)
            {
                var newWagon = new Wagon();
                newWagon.AddAnimal(animal);
                Wagons.Add(newWagon);
            }
        }

        // await AnsiConsole.Progress()
        //     .StartAsync(async ctx =>
        //     {
        //         // Define tasks
        //         var task2 = ctx.AddTask("[green]Feeding the animals...[/]");
        //         var task1 = ctx.AddTask("[green]Adding animals to carts.[/]");
        //         
        //         while (!ctx.IsFinished)
        //         {
        //             // Simulate some work
        //             await Task.Delay(250);
        //
        //             // Increment
        //             task1.Increment(10);
        //             task2.Increment(22);
        //         }
        //     });

        for (int i = 0; i < Wagons.Count(); i++)
        {
            AnsiConsole.Markup($"[red]wagon {i + 1}: {Wagons[i]}[/] \n");
            // Thread.Sleep(200);
        }

        Console.ReadLine();
    }
}
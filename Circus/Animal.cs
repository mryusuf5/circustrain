using Spectre.Console;

namespace Circus;

public enum animalSize
{
    small = 1,
    medium = 3,
    large = 5
}

public enum diet
{
    Carnivore,
    Herbivore
}

public class Animal
{
    public animalSize Size { get; set; }
    public diet Diet { get; set; }
    
    Random Random = new Random();

    public Animal(diet diet, animalSize size)
    {
        this.Diet = diet;
        this.Size = size;
    }

    public override string ToString()
    {
        string carnivoreStatus = "";
        
        if (this.Diet == diet.Carnivore)
        {
            carnivoreStatus = "Carnivore";
        }
        else
        {
            carnivoreStatus = "Herbivore";
        }
        
        return $"|{this.Size} - {carnivoreStatus}| ";
    }

    private animalSize generateSize()
    {
        int index = Random.Next(3);

        int[] possibleValues = { 1, 3, 5 };
        int randomValue = possibleValues[index];

        switch (randomValue)
        {
            case 1:
                return animalSize.small;
            case 3:
                return animalSize.medium;
            case 5:
                return animalSize.large;
            default:
                throw new InvalidOperationException("Something went wrong");
        }
    }
}
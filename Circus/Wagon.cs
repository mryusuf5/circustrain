namespace Circus;

public class Wagon
{
    private readonly int Size = 10;
    private List<Animal> Animals { get; set; }
    public int TotalPoints => Animals.Sum(a => (int)a.Size); 

    public Wagon()
    {
        Animals = new List<Animal>();
    }

    public override string ToString()
    {
        string wagon = "";
        foreach (Animal animal in Animals)
        {
            wagon += animal.ToString();
        }

        return wagon;
    }

    public bool CanAddAnimal(Animal animal)
    {
        if (TotalPoints + (int)animal.Size > this.Size)
        {
            return false; 
        }

        foreach (var existingAnimal in Animals)
        {
            if (existingAnimal.Diet == diet.Carnivore &&
                animal.Diet == diet.Carnivore)
            {
                return false;
            }

            if (existingAnimal.Diet == diet.Carnivore &&
                existingAnimal.Size >= animal.Size && animal.Diet == diet.Herbivore)
            {
                return false;
            }
        }

        return true;
    }
    
    public void AddAnimal(Animal animal)
    {
        if (CanAddAnimal(animal))
        {
            Animals.Add(animal);
        }
        else
        {
            throw new InvalidOperationException("Cannot add animal to the wagon. It would violate the rules.");
        }
    }
}
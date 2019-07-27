namespace AnimalCentre.Models.Contracts
{
    public interface IAnimal
    {
        string Name { get; set; }
        int Happiness { get; set; }
        int Energy { get; set; }
        int ProduceTime { get; set; }
        string Owner { get; set; }
        bool IsAdopt { get; set; }
        bool IsChipped { get; set; }
        bool IsVaccinated { get; set; }
    }
}

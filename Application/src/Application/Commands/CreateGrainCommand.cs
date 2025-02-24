using System.Windows.Input;

public class CreateGrainCommand : ICommand
{
    public Guid Id { get; }
    public string GrainType { get; }

    public CreateGrainCommand(Guid id, string grainType)
    {
        Id = id;
        GrainType = grainType;
    }
}

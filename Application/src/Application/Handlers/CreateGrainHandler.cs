public class CreateGrainHandler : ICommandHandler<CreateGrainCommand>
{
    private readonly IClusterClient _clusterClient;

    public CreateGrainHandler(IClusterClient clusterClient)
    {
        _clusterClient = clusterClient;
    }

    public async Task<Unit> Handle(CreateGrainCommand request, CancellationToken cancellationToken)
    {
        var grain = _clusterClient.GetGrain<IGrain>(request.Id);
        await grain.InitializeAsync(request.GrainType);

        return Unit.Value;
    }
}
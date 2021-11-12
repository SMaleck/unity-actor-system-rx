namespace ActorSystemRx.Creation
{
    public interface IStandaloneActorFactory
    {
        IActor SetupStandalone(IMonoActor standaloneActor);
    }
}
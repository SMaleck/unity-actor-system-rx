namespace ActorSystemRx.Creation
{
    public interface IActorOwnerFactory
    {
        IConnectableActor CreateOwner();
    }
}
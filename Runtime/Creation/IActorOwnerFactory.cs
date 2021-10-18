namespace ActorSystem.Creation
{
    public interface IActorOwnerFactory
    {
        IConnectableActor CreateOwner();
    }
}
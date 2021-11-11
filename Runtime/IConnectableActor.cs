using ActorSystemRx.LifeCycle;

namespace ActorSystemRx
{
    public interface IConnectableActor : IActor, IComponentOwner, IActorLifeCycleOwner
    {
    }
}

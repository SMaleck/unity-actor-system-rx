using ActorSystem.LifeCycle;

namespace ActorSystem
{
    public interface IConnectableActor : IActor, IComponentOwner, IActorLifeCycleOwner
    {
    }
}

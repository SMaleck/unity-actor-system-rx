using ActorSystemRx.Components;
using ActorSystemRx.LifeCycle;

namespace ActorSystemRx
{
    public interface IMonoActor : IActor, IActorLifeCycleOwner
    {
        void SetOwner(IConnectableActor actor);
        IActorComponent[] GetMonoComponents();
    }
}

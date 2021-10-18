using ActorSystem.Components;
using ActorSystem.LifeCycle;

namespace ActorSystem
{
    public interface IMonoActor : IActor, IActorLifeCycleOwner
    {
        void SetOwner(IConnectableActor actor);
        IActorComponent[] GetMonoComponents();
    }
}

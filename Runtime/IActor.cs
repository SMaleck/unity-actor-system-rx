using ActorSystem.Components;

namespace ActorSystem
{
    public interface IActor
    {
        T Get<T>() where T : class, IActorComponent;
        bool TryGet<T>(out T component) where T : class, IActorComponent;
        bool Has<T>() where T : class, IActorComponent;
    }
}

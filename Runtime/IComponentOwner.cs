using ActorSystem.Components;

namespace ActorSystem
{
    public interface IComponentOwner
    {
        IComponentOwner Attach(IActorComponent component);
    }
}

using ActorSystemRx.Components;

namespace ActorSystemRx
{
    public interface IComponentOwner
    {
        IComponentOwner Attach(IActorComponent component);
    }
}

using ActorSystemRx.Views;

namespace ActorSystemRx.Registration
{
    public interface IActorRegistrar
    {
        void Register(IActorView actorView);
        void Register(IActor actor);
    }
}

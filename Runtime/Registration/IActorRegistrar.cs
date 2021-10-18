using ActorSystem.Views;

namespace ActorSystem.Registration
{
    public interface IActorRegistrar
    {
        void Register(IActorView actorView);
        void Register(IActor actor);
    }
}

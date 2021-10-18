using ActorSystem.Views;

namespace ActorSystem.Creation
{
    public interface IPartialControllerFactory
    {
        void Create(IActor actor, IPartialActorView view);
    }
}
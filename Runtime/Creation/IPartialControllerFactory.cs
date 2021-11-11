using ActorSystemRx.Views;

namespace ActorSystemRx.Creation
{
    public interface IPartialControllerFactory
    {
        void Create(IActor actor, IPartialActorView view);
    }
}
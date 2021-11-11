using ActorSystemRx.Registration;
using Zenject;

namespace ActorSystemRx.Views
{
    public class StandaloneActorView : ActorView
    {
        [Inject]
        private void Inject(IActorRegistrar actorRegistrar)
        {
            actorRegistrar.Register(this);
        }
    }
}

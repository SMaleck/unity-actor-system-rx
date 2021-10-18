using ActorSystem.Registration;
using Zenject;

namespace ActorSystem.Views
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

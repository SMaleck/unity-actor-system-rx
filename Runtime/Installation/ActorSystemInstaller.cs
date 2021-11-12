using Zenject;

namespace ActorSystemRx.Installation
{
    public class ActorSystemInstaller : Installer<ActorSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<
                    Actor,
                    Actor.Factory>()
                .AsSingle();
        }
    }
}

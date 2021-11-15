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

            Container.BindFactory<
                    UnityEngine.Object, 
                    MonoActor, 
                    MonoActor.Factory>()
                .FromFactory<PrefabFactory<MonoActor>>();
        }
    }
}

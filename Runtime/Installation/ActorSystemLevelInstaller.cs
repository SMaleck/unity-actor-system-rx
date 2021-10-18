using ActorSystem.Views;
using Zenject;

namespace ActorSystem.Installation
{
    public class ActorSystemLevelInstaller : Installer<ActorSystemLevelInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<
                    Actor,
                    Actor.Factory>()
                .AsSingle();

            // ---------------------------------------------- VIEWS
            Container.BindFactory<UnityEngine.Object, ActorView, ActorView.Factory>()
                    .FromFactory<PrefabFactory<ActorView>>();

            Container.BindFactory<
                    IActor,
                    IActorView,
                    ActorController,
                    ActorController.Factory>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<StandaloneActorController>()
                .AsSingle().NonLazy();
        }
    }
}

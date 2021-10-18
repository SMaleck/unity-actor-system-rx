using ActorSystem.Creation;
using ActorSystem.LifeCycle;
using ActorSystem.Utility;
using UtilitiesGeneral.Extensions;
using Zenject;

namespace ActorSystem.Views
{
    public class ActorController : DisposableActorSystemElement
    {
        public class Factory : PlaceholderFactory<IActor, IActorView, ActorController> { }

        public ActorController(
            IActor actor,
            IActorView view,
            IPartialControllerFactory controllerFactory)
        {
            ConnectActors(view.MonoActor, actor);
            SetupViews(actor, view, controllerFactory);
        }

        private void ConnectActors(IMonoActor monoActor, IActor owner)
        {
            if (owner is IConnectableActor connectableActor)
            {
                monoActor.SetOwner(connectableActor);
            }

            if (owner is IActorLifeCycleOwner lifeCycleOwner)
            {
                this.AddTo(lifeCycleOwner.LifeCycle);
            }
        }

        private void SetupViews(IActor actor, IActorView view, IPartialControllerFactory controllerFactory)
        {
            view.PartialViews
                .ForEach(e => controllerFactory.Create(actor, e));
        }
    }
}

using ActorSystemRx.Utility;
using ActorSystemRx.Creation;
using ActorSystemRx.LifeCycle;
using ActorSystemRx.Registration;
using UtilitiesGeneral.Extensions;

namespace ActorSystemRx.Views
{
    public class StandaloneActorController : DisposableActorSystemElement
    {
        private readonly IActorOwnerFactory _actorFactory;
        private readonly IPartialControllerFactory _controllerFactory;
        private readonly IActorRegistrar _actorRegistrar;

        private IActorView _view;
        private IActor Actor => _view.MonoActor;

        public StandaloneActorController(
            IActorOwnerFactory actorFactory,
            IPartialControllerFactory controllerFactory,
            IActorRegistrar actorRegistrar)
        {
            _actorFactory = actorFactory;
            _controllerFactory = controllerFactory;
            _actorRegistrar = actorRegistrar;
        }

        public void Setup(IActorView view)
        {
            _view = view;
            var ownerActor = _actorFactory.CreateOwner();

            ConnectActors(view.MonoActor, ownerActor);
            SetupViews(Actor, view, _controllerFactory);

            _actorRegistrar.Register(Actor);

            ownerActor.StartActor();
        }

        private void ConnectActors(IMonoActor monoActor, IConnectableActor owner)
        {
            monoActor.SetOwner(owner);
            this.AddTo(monoActor.LifeCycle);
        }

        private void SetupViews(IActor actor, IActorView view, IPartialControllerFactory controllerFactory)
        {
            view.PartialViews
                .ForEach(e => controllerFactory.Create(actor, e));
        }
    }
}

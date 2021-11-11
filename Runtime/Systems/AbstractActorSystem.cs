using ActorSystemRx.LifeCycle;

namespace ActorSystemRx.Systems
{
    public abstract class AbstractActorSystem : DisposableActorSystemElement, IActorSystem, IStartableSystem
    {
        protected IActor Actor { get; }

        protected AbstractActorSystem(IActor actor)
        {
            Actor = actor;

            if (Actor is IActorLifeCycleOwner lifeCycleOwner)
            {
                lifeCycleOwner.AttachSystem(this);
            }
        }

        void IStartableSystem.StartLifeCycle()
        {
            StartInternal();
        }

        protected virtual void StartInternal() { }
    }
}

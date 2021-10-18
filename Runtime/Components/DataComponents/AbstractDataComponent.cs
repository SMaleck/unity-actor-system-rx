using ActorSystem.LifeCycle;

namespace ActorSystem.Components.DataComponents
{
    public class AbstractDataComponent : DisposableActorSystemElement, IActorComponent, IStartableComponent
    {
        void IStartableComponent.StartLifeCycle()
        {
            StartInternal();
        }

        protected virtual void StartInternal() { }
    }
}

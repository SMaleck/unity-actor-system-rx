using ActorSystem.LifeCycle;
using UnityEngine;
using UtilitiesUniRx.Utility;
using Zenject;

namespace ActorSystem.Components.MonoComponents
{
    public class AbstractMonoComponent : MonoBehaviour, IActorComponent, IStartableComponent
    {
        protected IActorLifeCycle LifeCycle = ActorLifeCycle.Create();

        [Inject]
        private void Inject([InjectLocal] IDisposer disposer)
        {
            LifeCycle.SetParentDisposer(disposer);
        }

        void IStartableComponent.StartLifeCycle()
        {
            StartInternal();
        }

        protected virtual void StartInternal() { }

        public void Dispose()
        {
            LifeCycle?.Reset();
            OnDispose();
        }

        protected virtual void OnDispose() { }
    }
}

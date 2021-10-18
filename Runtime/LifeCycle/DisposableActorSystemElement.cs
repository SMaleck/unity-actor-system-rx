using System;
using UtilitiesUniRx.Utility;
using Zenject;

namespace ActorSystem.LifeCycle
{
    public class DisposableActorSystemElement : IDisposable
    {
        protected IActorLifeCycle LifeCycle = ActorLifeCycle.Create();

        [Inject]
        private void Inject([InjectLocal] IDisposer disposer)
        {
            LifeCycle.SetParentDisposer(disposer);
        }

        public void Dispose()
        {
            LifeCycle?.Reset();
            OnDispose();
        }

        protected virtual void OnDispose() { }
    }
}

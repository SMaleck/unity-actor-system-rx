using System;
using UniRx;
using UtilitiesUniRx.Utility;

namespace ActorSystemRx.LifeCycle
{
    public class ActorLifeCycle : IActorLifeCycle
    {
        private readonly SerialDisposable _serial = new SerialDisposable();
        private IDisposer _parent;

        private CompositeDisposable Composite
        {
            get => _serial.Disposable as CompositeDisposable;
            set => _serial.Disposable = value;
        }

        public static IActorLifeCycle Create()
        {
            return new ActorLifeCycle();
        }

        public void SetParentDisposer(IDisposer parent)
        {
            if (_parent != null)
            {
                throw new InvalidOperationException($"Parent already set on {nameof(ActorLifeCycle)}");
            }

            _parent = parent;
            _parent.Add(_serial);
        }

        public void Add(IDisposable disposable)
        {
            if (_serial.IsDisposed)
            {
                disposable.Dispose();
            }
            else
            {
                if (Composite == null)
                    Composite = new CompositeDisposable();
                Composite.Add(disposable);
            }
        }

        public void Reset()
        {
            Composite = null;
        }
    }
}

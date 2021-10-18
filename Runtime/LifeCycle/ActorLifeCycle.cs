using System;
using System.Collections.Generic;
using UniRx;
using UtilitiesUniRx.Utility;

namespace ActorSystem.LifeCycle
{
    public class ActorLifeCycle : IActorLifeCycle
    {
        private readonly SerialDisposable _serial = new SerialDisposable();
        private IDisposer _parent;

        private List<Action> _onStartActions;
        private List<Action> _onResetActions;

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

        private CompositeDisposable Composite
        {
            get => _serial.Disposable as CompositeDisposable;
            set => _serial.Disposable = value;
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

        public void OnStart(Action onStart)
        {
            if (!_onStartActions.Contains(onStart))
            {
                _onStartActions.Add(onStart);
            }
        }

        public void OnReset(Action onReset)
        {
            if (!_onResetActions.Contains(onReset))
            {
                _onResetActions.Add(onReset);
            }
        }

        public void Start()
        {
            _onStartActions.ForEach(e => e?.Invoke());
        }

        public void Reset()
        {
            Composite = null;
        }
    }
}

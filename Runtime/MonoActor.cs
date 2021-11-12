using ActorSystemRx.Components;
using ActorSystemRx.LifeCycle;
using System;
using UnityEngine;
using UtilitiesGeneral.Extensions;
using Zenject;

namespace ActorSystemRx
{
    public class MonoActor : MonoBehaviour, IMonoActor
    {
        public class Factory : PlaceholderFactory<UnityEngine.Object, MonoActor> { }

        protected IConnectableActor _owningActor;
        protected IActorComponent[] _monoComponents;

        public IActorLifeCycle LifeCycle => _owningActor.LifeCycle;

        public void SetOwner(IConnectableActor actor)
        {
            if (_owningActor != null)
            {
                return;
            }

            GetComponentsInChildren<IActorComponent>()
                .ForEach(e => actor.Attach(e));

            _owningActor = actor;
        }

        IActorComponent[] IMonoActor.GetMonoComponents()
        {
            return _monoComponents ?? (_monoComponents = GetComponentsInChildren<IActorComponent>());
        }

        public T Get<T>() where T : class, IActorComponent
        {
            return _owningActor.Get<T>();
        }

        public bool TryGet<T>(out T component) where T : class, IActorComponent
        {
            return _owningActor.TryGet<T>(out component);
        }

        public bool Has<T>() where T : class, IActorComponent
        {
            return _owningActor.Has<T>();
        }

        public bool Has(Type type)
        {
            return _owningActor.Has(type);
        }

        public void StartActor()
        {
            _owningActor.StartActor();
        }

        public void AttachSystem(IStartableSystem startableSystem)
        {
            _owningActor.AttachSystem(startableSystem);
        }

        public void OnStart(Action onStartAction)
        {
            _owningActor.OnStart(onStartAction);
        }

        public void ResetActor()
        {
            _owningActor.ResetActor();
        }
    }
}

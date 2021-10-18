using System;
using ActorSystem.Components;
using ActorSystem.LifeCycle;
using UnityEngine;
using UtilitiesGeneral.Extensions;

namespace ActorSystem
{
    public class MonoActor : MonoBehaviour, IMonoActor
    {
        private IConnectableActor _actor;
        private IActorComponent[] _monoComponents;

        public IActorLifeCycle LifeCycle => _actor.LifeCycle;

        public void SetOwner(IConnectableActor actor)
        {
            if (_actor != null)
            {
                return;
            }

            GetComponentsInChildren<IActorComponent>()
                .ForEach(e => actor.Attach(e));

            _actor = actor;
        }

        IActorComponent[] IMonoActor.GetMonoComponents()
        {
            return _monoComponents ?? (_monoComponents = GetComponentsInChildren<IActorComponent>());
        }

        public T Get<T>() where T : class, IActorComponent
        {
            return _actor.Get<T>();
        }

        public bool TryGet<T>(out T component) where T : class, IActorComponent
        {
            return _actor.TryGet<T>(out component);
        }

        public bool Has<T>() where T : class, IActorComponent
        {
            return _actor.Has<T>();
        }

        public void StartActor()
        {
            _actor.StartActor();
        }

        public void AttachSystem(IStartableSystem startableSystem)
        {
            _actor.AttachSystem(startableSystem);
        }

        public void OnStart(Action onStartAction)
        {
            _actor.OnStart(onStartAction);
        }

        public void ResetActor()
        {
            _actor.ResetActor();
        }
    }
}

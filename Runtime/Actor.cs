﻿using ActorSystemRx.Components;
using ActorSystemRx.LifeCycle;
using ActorSystemRx.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using UtilitiesGeneral.Extensions;
using UtilitiesGeneral.Logging;
using Zenject;

namespace ActorSystemRx
{
    public class Actor : DisposableActorSystemElement, IConnectableActor
    {
        public class Factory : PlaceholderFactory<Actor> { }

        private readonly ILogger _logger;
        private readonly Dictionary<Type, IActorComponent> _actorComponents = new Dictionary<Type, IActorComponent>();

        private readonly List<IStartableComponent> _startableComponents = new List<IStartableComponent>();
        private readonly List<IStartableSystem> _startableSystems = new List<IStartableSystem>();
        private readonly List<Action> _additionalStartActions = new List<Action>();

        IActorLifeCycle IActorLifeCycleOwner.LifeCycle => base.LifeCycle;

        public Actor(ILogger logger)
        {
            _logger = logger;
        }

        public T Get<T>() where T : class, IActorComponent
        {
            if (TryGet<T>(out var component))
            {
                return component as T;
            }

            _logger.Warn($"No DataComponent of type [{(typeof(T).Name)}] found");
            return null;
        }

        public bool TryGet<T>(out T component) where T : class, IActorComponent
        {
            var result = _actorComponents.TryGetValue(typeof(T), out var actorComponent);
            component = result ? (T)actorComponent : null;

            return result;
        }

        public bool Has<T>() where T : class, IActorComponent
        {
            return TryGet<T>(out _);
        }

        public bool Has(Type type)
        {
            foreach (var component in _actorComponents.Values)
            {
                if (component.GetType().GetInterfaces().Contains(type))
                {
                    return true;
                }
            }

            return false;
        }

        void IActorLifeCycleOwner.StartActor()
        {
            foreach (var component in _startableComponents)
            {
                component.StartLifeCycle();
                component.AddTo(LifeCycle);
            }

            foreach (var system in _startableSystems)
            {
                system.StartLifeCycle();
                system.AddTo(LifeCycle);
            }

            foreach (var action in _additionalStartActions)
            {
                action.Invoke();
            }
        }

        void IActorLifeCycleOwner.ResetActor()
        {
            Dispose();
        }

        void IActorLifeCycleOwner.AttachSystem(IStartableSystem startableSystem)
        {
            if (!_startableSystems.Contains(startableSystem) &&
                startableSystem != null)
            {
                _startableSystems.Add(startableSystem);
            }
        }

        void IActorLifeCycleOwner.OnStart(Action onStart)
        {
            if (!_additionalStartActions.Contains(onStart) &&
                onStart != null)
            {
                _additionalStartActions.Add(onStart);
            }
        }

        IComponentOwner IComponentOwner.Attach(IActorComponent component)
        {
            GetKeyableTypes(component)
                .ForEach(type => _actorComponents.Add(type, component));

            _startableComponents.Add((IStartableComponent)component);

            return this;
        }

        private IReadOnlyList<Type> GetKeyableTypes(IActorComponent component)
        {
            var types = component
                .GetType()
                .GetInterfaces()
                .Where(IsKeyableInterface)
                .ToArray();

            return types.Any()
                ? types
                : new[] { component.GetType() };
        }

        private bool IsKeyableInterface(Type type)
        {
            return !type.Name.Equals(nameof(IActorComponent), StringComparison.InvariantCultureIgnoreCase) &&
                   typeof(IActorComponent).IsAssignableFrom(type);
        }
    }
}

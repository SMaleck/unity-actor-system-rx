﻿using ActorSystemRx.Utility;
using ActorSystemRx.LifeCycle;

namespace ActorSystemRx.Views.Partials
{
    public class AbstractPartialActorController : DisposableActorSystemElement
    {
        protected readonly IActor Actor;

        protected AbstractPartialActorController(IActor actor)
        {
            Actor = actor;

            var lifeCycleOwner = (IActorLifeCycleOwner)actor;

            this.AddTo(lifeCycleOwner.LifeCycle);
            lifeCycleOwner.OnStart(StartInternal);
        }

        protected virtual void StartInternal() { }
    }
}

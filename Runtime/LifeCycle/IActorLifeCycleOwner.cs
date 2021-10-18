using System;

namespace ActorSystem.LifeCycle
{
    public interface IActorLifeCycleOwner
    {
        IActorLifeCycle LifeCycle { get; }

        void StartActor();
        void AttachSystem(IStartableSystem startableSystem);
        void OnStart(Action onStartAction);

        void ResetActor();
    }
}

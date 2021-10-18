using System;

namespace ActorSystem.LifeCycle
{
    public interface IStartableComponent : IDisposable
    {
        void StartLifeCycle();
    }
}

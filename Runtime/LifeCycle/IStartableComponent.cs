using System;

namespace ActorSystemRx.LifeCycle
{
    public interface IStartableComponent : IDisposable
    {
        void StartLifeCycle();
    }
}

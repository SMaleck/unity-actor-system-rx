using System;

namespace ActorSystemRx.LifeCycle
{
    public interface IStartableSystem : IDisposable
    {
        void StartLifeCycle();
    }
}

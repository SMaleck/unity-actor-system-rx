using System;

namespace ActorSystem.LifeCycle
{
    public interface IStartableSystem : IDisposable
    {
        void StartLifeCycle();
    }
}

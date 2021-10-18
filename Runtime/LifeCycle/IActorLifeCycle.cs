using UtilitiesUniRx.Utility;

namespace ActorSystem.LifeCycle
{
    public interface IActorLifeCycle : IDisposer
    {
        void Reset();
        void SetParentDisposer(IDisposer parent);
    }
}

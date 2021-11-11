using UtilitiesUniRx.Utility;

namespace ActorSystemRx.LifeCycle
{
    public interface IActorLifeCycle : IDisposer
    {
        void Reset();
        void SetParentDisposer(IDisposer parent);
    }
}

using System;
using UniRx;
using UtilitiesUniRx.Utility;

namespace ActorSystemRx.Utility
{
    public static class DisposerExtensions
    {
        public static IDisposer OnDisposal(this IDisposer disposer, Action action)
        {
            disposer.Add(Disposable.Create(action));
            return disposer;
        }

        public static T AddTo<T>(this T disposable, IDisposer disposer) where T : IDisposable
        {
            disposer.Add(disposable);
            return disposable;
        }
    }
}

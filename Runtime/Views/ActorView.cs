using UnityEngine;
using Zenject;

namespace ActorSystem.Views
{
    public class ActorView : MonoBehaviour, IActorView
    {
        public class Factory : PlaceholderFactory<UnityEngine.Object, ActorView> { }

        private IMonoActor _monoActor;
        public IMonoActor MonoActor => GetMonoActor();

        private IPartialActorView[] _partialViews;
        public IPartialActorView[] PartialViews => GetPartialViews();

        private IMonoActor GetMonoActor()
        {
            return _monoActor = _monoActor ?? GetComponentInChildren<IMonoActor>();
        }

        private IPartialActorView[] GetPartialViews()
        {
            return _partialViews = _partialViews ?? GetComponentsInChildren<IPartialActorView>();
        }
    }
}

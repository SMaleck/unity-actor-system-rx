using ActorSystemRx.Creation;
using UnityEngine;
using Zenject;

namespace ActorSystemRx
{
    public class StandaloneMonoActor : MonoActor
    {
        [SerializeField] private bool _autoStart = true;

        [Inject]
        private void Inject(IStandaloneActorFactory standaloneActorFactory)
        {
            standaloneActorFactory.SetupStandalone(this);

            if (_autoStart)
            {
                StartActor();
            }
        }
    }
}

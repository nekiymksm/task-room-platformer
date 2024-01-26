using _project.Scripts.Configs;
using _project.Scripts.CoreControl;
using _project.Scripts.CoreControl.Base;
using _project.Scripts.Features.Location;
using _project.Scripts.Features.StateObserving;
using _project.Scripts.Features.StateObserving.Base;

namespace _project.Scripts.Features.Player
{
    public class PlayerCharacterInstanceHandler : InstanceHandler<PlayerCharacterInstance>, IStateObservable
    {
        private GlobalContainer _globalContainer;
        
        public void Notify(GameStateKind stateKind)
        {
            switch (stateKind)
            {
                case GameStateKind.Restart:
                {
                    GetInstance().ResetCharacter(_globalContainer.GetHandler<LocationLoadHandler>()
                        .CurrentLocationView.CharacterLoadPointTransform.position);
                }
                    break;
            }
        }

        protected override PlayerCharacterInstance Create() 
            => ConfigsCollection.GetConfig<PlayerCharacterConfig>().Create();
        
        protected override void OnRun()
        {
            _globalContainer = GlobalContainer.Instance;
            _globalContainer.GetHandler<GameStateHandler>().AddObserver(this);
        }
    }
}
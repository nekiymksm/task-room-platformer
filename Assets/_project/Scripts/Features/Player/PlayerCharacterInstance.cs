using _project.Scripts.Configs;
using _project.Scripts.Configs.Base;
using _project.Scripts.CoreControl;
using _project.Scripts.Features.Input;
using _project.Scripts.Features.ViewTracking.Base;
using UnityEngine;

namespace _project.Scripts.Features.Player
{
    public class PlayerCharacterInstance : MonoBehaviour, ITrackable, IGuided<PlayerCharacterConfig>
    {
        [SerializeField] private PlayerCharacterMovement _playerCharacterMovement;
        [SerializeField] private PlayerCharacterAnimationsControl _playerCharacterAnimationsControl;

        public Vector3 CurrentPosition => transform.position;
        
        public void Guide(PlayerCharacterConfig config)
        {
            var handler = GlobalContainer.Instance.GetHandler<InputHandler>();
            
            _playerCharacterAnimationsControl.Init(config);
            _playerCharacterMovement.Init(config, handler, _playerCharacterAnimationsControl);
        }

        public void TakeHit()
        {
            gameObject.SetActive(false);
        }
    }
}
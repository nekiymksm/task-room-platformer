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
        [SerializeField] private Rigidbody[] _bonesRigidbodies;

        public Vector3 CurrentPosition => transform.position;

        private void Awake()
        {
            SetRagDoll(false);
        }

        public void Guide(PlayerCharacterConfig config)
        {
            var handler = GlobalContainer.Instance.GetHandler<InputHandler>();
            
            _playerCharacterAnimationsControl.Init(config);
            _playerCharacterMovement.Init(config, handler, _playerCharacterAnimationsControl);
        }

        public void TakeHit()
        {
            SetRagDoll(true);
        }

        public void ResetCharacter(Vector3 resetPointPosition)
        {
            SetRagDoll(false);
            transform.position = resetPointPosition;
        }
        
        private void SetRagDoll(bool isPhysic)
        {
            _playerCharacterMovement.SetBlocking(isPhysic);
            _playerCharacterAnimationsControl.SetBlock(isPhysic);
            
            foreach (var bone in _bonesRigidbodies)
            {
                bone.isKinematic = !isPhysic;
                bone.detectCollisions = isPhysic;
            }
        }
    }
}
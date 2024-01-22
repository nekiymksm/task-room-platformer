using _project.Scripts.CoreControl.Handlers;
using UnityEngine;

namespace _project.Scripts.PlayerCharacter
{
    public class CharacterAnimator : MonoBehaviour
    {
        private enum CharacterMove
        {
            Forward,
            Jump,
        }
        
        [SerializeField] private Animator _animator;

        private InputHandler _inputHandler;
        private CharacterMovement _characterMovement;

        private void Update()
        {
            _animator.SetBool(
                _animator.parameters[(int) CharacterMove.Forward].nameHash, 
                _characterMovement.IsGrounded && _inputHandler.HorizontalAxis != 0);

            if (_characterMovement.IsGrounded)
            {
                transform.rotation = Quaternion.Euler(0, _inputHandler.HorizontalAxis * -90, 0);
            }

            if (_characterMovement.IsGrounded && _inputHandler.JumpAxis > 0)
            {
                _animator.SetTrigger(_animator.parameters[(int) CharacterMove.Jump].nameHash);
            }
        }

        public void Init(InputHandler inputHandler, CharacterMovement characterMovement)
        {
            _inputHandler = inputHandler;
            _characterMovement = characterMovement;
        }
    }
}
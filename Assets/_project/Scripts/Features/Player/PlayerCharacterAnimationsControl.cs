using _project.Scripts.Configs;
using _project.Scripts.Features.Input;
using _project.Scripts.Features.Input.Base;
using UnityEngine;

namespace _project.Scripts.Features.Player
{
    public class PlayerCharacterAnimationsControl : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private InputHandler _inputHandler;
        private PlayerCharacterMovement _playerCharacterMovement;
        private string _runParamName;
        private string _jumpParamName;

        private void Update()
        {
            _animator.SetBool(_runParamName, 
                _playerCharacterMovement.IsGrounded && _inputHandler.GetAxisValue(AxisKind.Horizontal) != 0);

            if (_playerCharacterMovement.IsGrounded && _inputHandler.GetAxisValue(AxisKind.Jump, true) > 0)
            {
                _animator.SetTrigger(_jumpParamName);
            }
        }

        public void Init(InputHandler inputHandler, PlayerCharacterMovement playerCharacterMovement, PlayerCharacterConfig playerCharacterConfig)
        {
            _inputHandler = inputHandler;
            _playerCharacterMovement = playerCharacterMovement;
            _runParamName = playerCharacterConfig.RunAnimationParamName;
            _jumpParamName = playerCharacterConfig.JumpAnimationParamName;
        }
    }
}
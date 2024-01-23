using _project.Scripts.CoreControl.Handlers;
using UnityEngine;

namespace _project.Scripts.PlayerCharacter
{
    public class CharacterAnimator : MonoBehaviour
    {
        private enum CharacterMove
        {
            Run,
            Jump,
        }
        
        [SerializeField] private Animator _animator;

        private InputHandler _inputHandler;
        private CharacterMovement _characterMovement;

        public string _runParam;
        public string _jumpParam;

        private void Start()
        {
            var param = _animator.parameters;
            
            _runParam = param[(int) CharacterMove.Run].name;
            _jumpParam = param[(int) CharacterMove.Jump].name;
        }

        private void Update()
        {
            _animator.SetBool(_runParam, _characterMovement.IsGrounded && _inputHandler.HorizontalAxis != 0);

            if (_characterMovement.IsGrounded && _inputHandler.JumpAxis > 0)
            {
                _animator.SetTrigger(_jumpParam);
            }
        }

        public void Init(InputHandler inputHandler, CharacterMovement characterMovement)
        {
            _inputHandler = inputHandler;
            _characterMovement = characterMovement;
        }
    }
}
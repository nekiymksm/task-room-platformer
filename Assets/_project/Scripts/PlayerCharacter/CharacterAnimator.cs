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

        public string RunParametr;
        public string JumpParametr;

        private void Start()
        {
            var parameters = _animator.parameters;
            
            RunParametr = parameters[(int) CharacterMove.Run].name;
            JumpParametr = parameters[(int) CharacterMove.Jump].name;
        }

        private void Update()
        {
            _animator.SetBool(RunParametr, _characterMovement.IsGrounded && _inputHandler.HorizontalAxis != 0);

            if (_characterMovement.IsGrounded && _inputHandler.JumpAxis > 0)
            {
                _animator.SetTrigger(JumpParametr);
            }
        }

        public void Init(InputHandler inputHandler, CharacterMovement characterMovement)
        {
            _inputHandler = inputHandler;
            _characterMovement = characterMovement;
        }
    }
}
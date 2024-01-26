using _project.Scripts.Configs;
using UnityEngine;

namespace _project.Scripts.Features.Player
{
    public class PlayerCharacterAnimationsControl : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private string _runParamName;
        private string _jumpParamName;

        public void Init(PlayerCharacterConfig playerCharacterConfig)
        {
            _runParamName = playerCharacterConfig.RunAnimationParamName;
            _jumpParamName = playerCharacterConfig.JumpAnimationParamName;
        }

        public void PlayRun(bool canPlay)
        {
            _animator.SetBool(_runParamName, canPlay);
        }
        
        public void PlayJump()
        {
            _animator.SetTrigger(_jumpParamName);
        }

        public void SetBlock(bool isBlock)
        {
            _animator.enabled = !isBlock;
        }
    }
}
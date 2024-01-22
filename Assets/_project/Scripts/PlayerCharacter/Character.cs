using _project.Scripts.Configs;
using _project.Scripts.Configs.Base;
using _project.Scripts.CoreControl.Containers;
using _project.Scripts.CoreControl.Handlers;
using _project.Scripts.ViewTracking;
using UnityEngine;

namespace _project.Scripts.PlayerCharacter
{
    public class Character : MonoBehaviour, ITrackable, IGuidable<CharacterConfig>
    {
        [SerializeField] private CharacterMovement _characterMovement;
        [SerializeField] private CharacterAnimator _characterAnimator;

        public Vector3 CurrentPosition => transform.position;
        
        public void Guide(CharacterConfig config)
        {
            GlobalContainer.Instance.TryGetHandler(out InputHandler handler);
            
            _characterMovement.Init(config, handler);
            _characterAnimator.Init(handler, _characterMovement);
        }
    }
}
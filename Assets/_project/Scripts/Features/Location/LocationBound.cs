using System;
using _project.Scripts.Features.Player;
using UnityEngine;

namespace _project.Scripts.Features.Location
{
    public class LocationBound : MonoBehaviour
    {
        [SerializeField] private Collider _selfCollider;
        [SerializeField] private bool _isExitRight;

        public event Action CharacterExit;
        
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerCharacterInstance character))
            {
                if (_isExitRight)
                {
                    if (character.transform.position.x > transform.position.x)
                    {
                        CharacterExit?.Invoke();
                        BlockBound();
                    }
                }
                else
                {
                    if (character.transform.position.x < transform.position.x)
                    {
                        CharacterExit?.Invoke();
                        BlockBound();
                    }
                }
            }
        }

        public void BlockBound()
        {
            _selfCollider.isTrigger = false;
        }
    }
}
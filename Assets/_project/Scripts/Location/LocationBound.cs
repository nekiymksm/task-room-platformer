using System;
using _project.Scripts.PlayerCharacter;
using UnityEngine;

namespace _project.Scripts.Location
{
    public class LocationBound : MonoBehaviour
    {
        [SerializeField] private bool _isExitRight;
        
        public event Action CharacterExit;
        
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Character character))
            {
                if (_isExitRight)
                {
                    if (character.transform.position.x > transform.position.x)
                    {
                        CharacterExit?.Invoke();
                    }
                }
                else
                {
                    if (character.transform.position.x < transform.position.x)
                    {
                        CharacterExit?.Invoke();
                    }
                }
            }
        }
    }
}
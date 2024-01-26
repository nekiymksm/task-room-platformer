using _project.Scripts.Features.Player;
using UnityEngine;

namespace _project.Scripts.Features.Location.Items
{
    [RequireComponent(typeof(Collider))]
    public class DamageImpactItem : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out PlayerCharacterInstance character))
            {
                character.TakeHit();
            }
        }
    }
}
using _project.Scripts.PlayerCharacter;
using UnityEngine;

namespace _project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [field:SerializeField] public Character CharacterPrefab { get; }
        [field:SerializeField] public float MoveForce { get; }
        [field:SerializeField] public float MaxMoveSpeed { get; }
        [field:SerializeField] public float JumpForce { get; }
    }
}
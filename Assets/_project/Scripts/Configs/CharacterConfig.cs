using _project.Scripts.Configs.Base;
using _project.Scripts.PlayerCharacter;
using UnityEngine;

namespace _project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
    public class CharacterConfig : GuideConfig<Character, CharacterConfig>
    {
        [field:SerializeField] public float MoveForce { get; private set; }
        [field:SerializeField] public float MaxMoveSpeed { get; private set; }
        [field:SerializeField] public float JumpForce { get; private set; }
        [field:SerializeField] public float RotationSpeed { get; private set; }
    }
}
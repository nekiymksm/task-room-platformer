using _project.Scripts.Configs.Base;
using _project.Scripts.Features.Player;
using UnityEngine;

namespace _project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "PlayerCharacterConfig", menuName = "Configs/PlayerCharacterConfig")]
    public class PlayerCharacterConfig : GuideConfig<PlayerCharacterInstance, PlayerCharacterConfig>
    {
        [field: SerializeField] public float MoveForce { get; private set; }
        [field: SerializeField] public float MaxMoveSpeed { get; private set; }
        [field: SerializeField] public float JumpForce { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public string RunAnimationParamName { get; private set; }
        [field: SerializeField] public string JumpAnimationParamName { get; private set; }
    }
}
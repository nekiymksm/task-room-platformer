using _project.Scripts.Configs.Base;
using _project.Scripts.Features.ViewTracking;
using UnityEngine;

namespace _project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "ViewTrackingCameraConfig", menuName = "Configs/ViewTrackingCameraConfig")]
    public class ViewTrackingCameraConfig : GuideConfig<ViewTrackingCamera, ViewTrackingCameraConfig>
    {
        [field: SerializeField] public float YAxisOffset { get; private set; }
        [field: SerializeField] public float ZAxisOffset { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
    }
}
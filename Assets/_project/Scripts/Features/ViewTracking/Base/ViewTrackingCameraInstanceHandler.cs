using _project.Scripts.Configs;
using _project.Scripts.CoreControl.Base;

namespace _project.Scripts.Features.ViewTracking.Base
{
    public class ViewTrackingCameraInstanceHandler : InstanceHandler<ViewTrackingCamera>
    {
        protected override ViewTrackingCamera Create() =>
            ConfigsCollection.GetConfig<ViewTrackingCameraConfig>().Create();
    }
}
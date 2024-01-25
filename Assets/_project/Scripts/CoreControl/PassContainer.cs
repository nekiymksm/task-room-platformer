using _project.Scripts.CoreControl.Base;
using _project.Scripts.Features.Location;
using _project.Scripts.Features.Scenes.Base;

namespace _project.Scripts.CoreControl
{
    public class PassContainer : HandlersContainer
    {
        protected override void OnRun()
        {
            GlobalContainer.Instance.GetHandler<LocationLoadHandler>().Load(SceneType.Pass);
        }
    }
}
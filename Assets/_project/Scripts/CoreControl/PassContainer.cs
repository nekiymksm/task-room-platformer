using _project.Scripts.CoreControl.Base;
using _project.Scripts.Features.Location;
using _project.Scripts.Features.Scenes.Base;

namespace _project.Scripts.CoreControl
{
    public class PassContainer : HandlersContainer
    {
        protected override void OnRun()
        {
            if (GlobalContainer.Instance.TryGetHandler(out LocationLoadHandler loadHandler))
            {
                loadHandler.Load(SceneType.Pass);
            }
        }
    }
}
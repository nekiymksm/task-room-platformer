using _project.Scripts.CoreControl.Containers;
using _project.Scripts.Location.Base;

namespace _project.Scripts.Location
{
    public class PassContainer : HandlersContainer
    {
        protected override void OnRun()
        {
            if (GlobalContainer.Instance.TryGetHandler(out LoadHandler loadHandler))
            {
                loadHandler.Load(LocationType.Pass);
            }
        }
    }
}
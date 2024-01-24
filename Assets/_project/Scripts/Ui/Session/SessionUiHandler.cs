using _project.Scripts.CoreControl;
using _project.Scripts.Features.Input;
using _project.Scripts.Features.Input.Base;
using _project.Scripts.Ui.Base;

namespace _project.Scripts.Ui.Session
{
    public class SessionUiHandler : UiHandler
    {
        private InputHandler _inputHandler;
        
        protected override void OnInit()
        {
            if (GlobalContainer.Instance.TryGetHandler(out InputHandler inputHandler))
            {
                _inputHandler = inputHandler;
            }
        }
    }
}
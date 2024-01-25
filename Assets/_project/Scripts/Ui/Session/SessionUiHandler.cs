using _project.Scripts.CoreControl;
using _project.Scripts.Features.Input;
using _project.Scripts.Ui.Base;

namespace _project.Scripts.Ui.Session
{
    public class SessionUiHandler : UiHandler
    {
        private InputHandler _inputHandler;
        private SessionPauseView _sessionPauseView;

        private void OnDestroy()
        {
            _inputHandler.CancelButtonDown -= OnCancelButtonDown;
        }

        protected override void OnInit()
        {
            _inputHandler = GlobalContainer.Instance.GetHandler<InputHandler>();
            _sessionPauseView = GetElement<SessionPauseView>();
        }

        protected override void OnRun()
        {
            _inputHandler.CancelButtonDown += OnCancelButtonDown;
        }

        private void OnCancelButtonDown()
        {
            if (_sessionPauseView.gameObject.activeSelf)
            {
                _sessionPauseView.Hide();
            }
            else
            {
                _sessionPauseView.Show();
            }
        }
    }
}
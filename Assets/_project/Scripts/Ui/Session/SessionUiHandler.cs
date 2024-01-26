using _project.Scripts.CoreControl;
using _project.Scripts.Features.Input;
using _project.Scripts.Features.StateObserving;
using _project.Scripts.Features.StateObserving.Base;
using _project.Scripts.Ui.Base;

namespace _project.Scripts.Ui.Session
{
    public class SessionUiHandler : UiHandler
    {
        private GameStateHandler _gameStateHandler;
        private InputHandler _inputHandler;
        private PauseView _pauseView;

        private void OnDestroy()
        {
            _inputHandler.CancelButtonDown -= OnCancelButtonDown;
        }

        protected override void OnInit()
        {
            var globalContainer = GlobalContainer.Instance;
            
            _gameStateHandler = globalContainer.GetHandler<GameStateHandler>();
            _inputHandler = globalContainer.GetHandler<InputHandler>();
            _pauseView = GetElement<PauseView>();
        }

        protected override void OnRun()
        {
            _inputHandler.CancelButtonDown += OnCancelButtonDown;
        }

        private void OnCancelButtonDown()
        {
            switch (_gameStateHandler.CurrentGameState)
            {
                case GameStateKind.Pause:
                    _pauseView.Hide();
                    _gameStateHandler.NotifyObservers(GameStateKind.Resume);
                    break;
                
                case GameStateKind.Resume:
                    _pauseView.Show();
                    _gameStateHandler.NotifyObservers(GameStateKind.Pause);
                    break;
            }
        }
    }
}
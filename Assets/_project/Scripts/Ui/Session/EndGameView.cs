using _project.Scripts.CoreControl;
using _project.Scripts.Features.StateObserving;
using _project.Scripts.Features.StateObserving.Base;
using _project.Scripts.Ui.Base;
using UnityEngine;
using UnityEngine.UI;

namespace _project.Scripts.Ui.Session
{
    public class EndGameView : UiElement
    {
        [SerializeField] private Button _restart;
        [SerializeField] private Button _exitMenu;

        private GameStateHandler _gameStateHandler;
        
        private void Start()
        {
            _restart.onClick.AddListener(OnRestartButtonClick);
            _exitMenu.onClick.AddListener(OnExitMenuButtonClick);
        }

        private void OnDestroy()
        {
            _restart.onClick.RemoveListener(OnRestartButtonClick);
            _exitMenu.onClick.RemoveListener(OnExitMenuButtonClick);
        }

        protected override void OnInit()
        {
            _gameStateHandler = GlobalContainer.Instance.GetHandler<GameStateHandler>();
        }

        protected override void OnHide()
        {
        }

        private void OnRestartButtonClick()
        {
            Hide();
            _gameStateHandler.NotifyObservers(GameStateKind.Restart);
        }

        private void OnExitMenuButtonClick()
        {
            _gameStateHandler.NotifyObservers(GameStateKind.Menu);
        }
    }
}
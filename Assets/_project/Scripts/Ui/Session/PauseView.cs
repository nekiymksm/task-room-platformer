using _project.Scripts.CoreControl;
using _project.Scripts.Features.StateObserving;
using _project.Scripts.Features.StateObserving.Base;
using _project.Scripts.Ui.Base;
using UnityEngine;
using UnityEngine.UI;

namespace _project.Scripts.Ui.Session
{
    public class PauseView : UiElement
    {
        [SerializeField] private Button _resume;
        [SerializeField] private Button _exitMenu;

        private GameStateHandler _gameStateHandler;
        
        private void Start()
        {
            _resume.onClick.AddListener(OnResumeButtonClick);
            _exitMenu.onClick.AddListener(OnExitMenuButtonClick);
        }

        private void OnDestroy()
        {
            _resume.onClick.RemoveListener(OnResumeButtonClick);
            _exitMenu.onClick.RemoveListener(OnExitMenuButtonClick);
        }

        protected override void OnInit()
        {
            _gameStateHandler = GlobalContainer.Instance.GetHandler<GameStateHandler>();
        }

        protected override void OnHide()
        {
        }

        private void OnResumeButtonClick()
        {
            Hide();
        }

        private void OnExitMenuButtonClick()
        {
            _gameStateHandler.NotifyObservers(GameStateKind.Menu);
        }
    }
}
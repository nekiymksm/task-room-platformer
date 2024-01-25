using _project.Scripts.CoreControl;
using _project.Scripts.Features.Scenes.Base;
using _project.Scripts.Ui.Base;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _project.Scripts.Ui.Session
{
    public class SessionPauseView : UiElement
    {
        [SerializeField] private Button _resume;
        [SerializeField] private Button _exitMenu;

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

        protected override void OnHide()
        {
        }

        private void OnResumeButtonClick()
        {
            Hide();
        }

        private void OnExitMenuButtonClick()
        {
            GlobalContainer.Instance.ResetInstances();
            SceneManager.LoadScene((int)SceneType.Menu);
        }
    }
}
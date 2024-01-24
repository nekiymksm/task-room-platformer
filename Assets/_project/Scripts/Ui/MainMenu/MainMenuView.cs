using _project.Scripts.Features.Scenes.Base;
using _project.Scripts.Ui.Base;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _project.Scripts.Ui.MainMenu
{
    public class MainMenuView : UiElement
    {
        [SerializeField] private Button _start;
        [SerializeField] private Button _exit;

        private void Start()
        {
            _start.onClick.AddListener(OnStartButtonClick);
            _exit.onClick.AddListener(OnExitButtonClick);
        }

        private void OnDestroy()
        {
            _start.onClick.RemoveListener(OnStartButtonClick);
            _exit.onClick.RemoveListener(OnExitButtonClick);
        }

        private void OnStartButtonClick()
        {
            SceneManager.LoadScene((int)SceneType.Pass);
        }

        private void OnExitButtonClick()
        {
            Application.Quit();
        }
    }
}
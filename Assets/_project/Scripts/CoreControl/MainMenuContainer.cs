using _project.Scripts.CoreControl.Base;
using _project.Scripts.Ui.MainMenu;
using UnityEngine;

namespace _project.Scripts.CoreControl
{
    public class MainMenuContainer : HandlersContainer
    {
        [SerializeField] private MainMenuUiHandler _uiHandler;
        
        protected override void OnInit()
        {
            AddHandler(_uiHandler);
        }
    }
}
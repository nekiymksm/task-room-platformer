using _project.Scripts.Ui.Base;

namespace _project.Scripts.Ui.MainMenu
{
    public class MainMenuUiHandler : UiHandler
    {
        protected override void OnRun()
        {
            GetElement<MainMenuView>().Show();
        }
    }
}
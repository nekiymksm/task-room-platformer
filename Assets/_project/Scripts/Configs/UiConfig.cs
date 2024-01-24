using _project.Scripts.Ui.MainMenu;
using _project.Scripts.Ui.Session;
using UnityEngine;

namespace _project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "UiConfig", menuName = "Configs/UiConfig")]
    public class UiConfig : ScriptableObject
    {
        [field: SerializeField] public MainMenuUiHandler MainMenuUiHandlerPrefab { get; private set; }
        [field: SerializeField] public SessionUiHandler SessionUiHandlerPrefab { get; private set; }
    }
}
using _project.Scripts.CoreControl.Base;
using _project.Scripts.Features.Input;
using _project.Scripts.Features.Location;
using _project.Scripts.Features.Player;
using _project.Scripts.Features.Scenes.Base;
using _project.Scripts.Features.ViewTracking.Base;
using UnityEngine.SceneManagement;

namespace _project.Scripts.CoreControl
{
    public class GlobalContainer : HandlersContainer
    {
        public static GlobalContainer Instance;

        protected override void OnInit()
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        
            AddHandler(new LocationLoadHandler());
            AddHandler(new PlayerCharacterInstanceHandler());
            AddHandler(new ViewTrackingCameraInstanceHandler());
            AddHandler(new InputHandler());
        }

        protected override void OnRun()
        {
            SceneManager.LoadScene((int)SceneType.Pass);
        }
    }
}
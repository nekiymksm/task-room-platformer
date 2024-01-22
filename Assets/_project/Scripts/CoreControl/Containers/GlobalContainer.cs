using _project.Scripts.CoreControl.Handlers;
using _project.Scripts.Location.Base;
using _project.Scripts.PlayerCharacter;
using _project.Scripts.ViewTracking;
using UnityEngine.SceneManagement;

namespace _project.Scripts.CoreControl.Containers
{
    public class GlobalContainer : HandlersContainer
    {
        public static GlobalContainer Instance;

        protected override void OnInit()
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        
            AddHandler(new LoadHandler());
            AddHandler(new CharacterInstanceHandler());
            AddHandler(new ViewTrackingCameraInstanceHandler());
            AddHandler(new InputHandler());
        }

        protected override void OnRun()
        {
            SceneManager.LoadScene((int)LocationType.Pass);
        }
    }
}
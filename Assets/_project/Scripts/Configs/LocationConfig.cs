using _project.Scripts.Features.Location.Base;
using _project.Scripts.Features.Location.Views;
using _project.Scripts.Features.Scenes.Base;
using UnityEngine;

namespace _project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "LocationConfig", menuName = "Configs/LocationConfig")]
    public class LocationConfig : ScriptableObject
    {
        [SerializeField] private LevelLocationView levelLocationViewPrefab;
        [SerializeField] private PassLocationView passLocationViewPrefab;

        public LocationView GetLocation(SceneType sceneType)
        {
            switch (sceneType)
            {
                case SceneType.Level:
                    return Instantiate(levelLocationViewPrefab);
                
                case SceneType.Pass:
                    return Instantiate(passLocationViewPrefab);
            }
            
            return Instantiate(passLocationViewPrefab);
        }
    }
}
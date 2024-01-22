using _project.Scripts.Location;
using _project.Scripts.Location.Base;
using UnityEngine;

namespace _project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "LocationConfig", menuName = "Configs/LocationConfig")]
    public class LocationConfig : ScriptableObject
    {
        [SerializeField] private LevelLocation _levelLocationPrefab;
        [SerializeField] private PassLocation _passLocationPrefab;

        public LoadableLocation GetLocation(LocationType locationType)
        {
            switch (locationType)
            {
                case LocationType.Level:
                    return Instantiate(_levelLocationPrefab);
                
                case LocationType.Pass:
                    return Instantiate(_passLocationPrefab);
            }
            
            return Instantiate(_passLocationPrefab);
        }
    }
}
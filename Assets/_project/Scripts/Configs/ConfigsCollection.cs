using _project.Scripts.Utils;
using UnityEngine;

namespace _project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "ConfigsCollection", menuName = "Configs/ConfigsCollection")]
    public class ConfigsCollection : ScriptableObject
    {
        [SerializeField] private ScriptableObject[] _configs;

        public T GetConfig<T>() where T : ScriptableObject
        {
            if (CollectionSearcher.TryGetItem(_configs, out T config))
            {
                return config;
            }

            Debug.LogError($"{typeof(T)}_config_not_found");
            return null;
        }
    }
}
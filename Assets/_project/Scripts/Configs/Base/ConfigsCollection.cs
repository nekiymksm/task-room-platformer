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
            if (CollectionItemSearcher.TryGetItem(_configs, out T config))
            {
                return config;
            }

            return null;
        }
    }
}
using UnityEngine;

namespace _project.Scripts.Configs.Base
{
    public abstract class GuideConfig<T, TK> : ScriptableObject 
        where T : Object, IGuidable<TK> 
        where TK : GuideConfig<T, TK>
    {
        [SerializeField] private T _prefab;
        
        public T Create()
        {
            var instance = Instantiate(_prefab);
            instance.Guide(this as TK);
            
            return instance;
        }
    }
}
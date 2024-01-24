using System.Collections.Generic;
using UnityEngine;

namespace _project.Scripts.Utils
{
    public class CollectionItemSearcher
    {
        public static bool TryGetItem<T, TK>(IEnumerable<TK> items, out T item) where T : class, TK
        {
            foreach (var collectionItem in items)
            {
                if (collectionItem.GetType() == typeof(T))
                {
                    item = collectionItem as T;
                    return true;
                }
            }
            
            Debug.LogError($"{typeof(T)}_not_found_at_the_collection_{typeof(TK)}");
            item = null;
            return false;
        }
    }
}
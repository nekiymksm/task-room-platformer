using System.Collections.Generic;

namespace _project.Scripts.Utils
{
    public class CollectionSearcher
    {
        public static bool TryGetItem<T, TK>(IEnumerable<TK> items, out T collectionItem) where T : class
        {
            foreach (var item in items)
            {
                if (items.GetType() == typeof(T))
                {
                    collectionItem = item as T;
                    return true;
                }
            }
            
            collectionItem = null;
            return false;
        }
    }
}
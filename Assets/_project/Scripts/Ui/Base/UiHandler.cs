using _project.Scripts.CoreControl.Base;
using _project.Scripts.Utils;
using UnityEngine;

namespace _project.Scripts.Ui.Base
{
    public abstract class UiHandler : MonoBehaviour, IHandler
    {
        [SerializeField] protected UiElement[] UiElements;

        protected HandlersContainer HandlersContainer;
        
        public void Init(HandlersContainer handlersContainer)
        {
            HandlersContainer = handlersContainer;
            
            foreach (var item in UiElements)
            {
                item.Init(this);
                item.Hide();
            }
            
            OnInit();
        }

        public void Run()
        {
            OnRun();
        }

        protected virtual void OnInit()
        {
        }

        protected virtual void OnRun()
        {
        }

        public T GetElement<T>() where T : UiElement
        {
            CollectionItemSearcher.TryGetItem(UiElements, out T element);
            return element;
        }
    }
}
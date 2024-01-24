using UnityEngine;

namespace _project.Scripts.Ui.Base
{
    public abstract class UiElement : MonoBehaviour
    {
        protected UiHandler UiHandler;
        
        public void Init(UiHandler uiHandler)
        {
            UiHandler = uiHandler;
            
            OnInit();
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
            
            OnShow();
        }

        public void Hide()
        {
            OnHide();
            
            gameObject.SetActive(false);
        }

        protected virtual void OnInit()
        {
        }
        
        protected virtual void OnShow()
        {
        }
        
        protected virtual void OnHide()
        {
        }
    }
}
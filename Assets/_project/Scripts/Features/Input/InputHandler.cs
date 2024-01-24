using System.Linq.Expressions;
using _project.Scripts.CoreControl.Base;
using _project.Scripts.Features.Input.Base;
using UnityEngine;

namespace _project.Scripts.Features.Input
{
    public class InputHandler : IHandler
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string JumpAxisName = "Jump";
        private const string CancelAxisName = "Cancel";
        
        private float _cancelAxisValue;
        private bool _isCancelPressed;
        
        public void Init(HandlersContainer handlersContainer)
        {
        }

        public void Run()
        {
        }

        public float GetAxisValue(AxisKind axisKind, bool isRaw = false)
        {
            string axisName = string.Empty;
            
            switch (axisKind)
            {
                case AxisKind.Horizontal:
                    axisName = HorizontalAxisName;
                    break;
                
                case AxisKind.Jump:
                    axisName = JumpAxisName;
                    break;
            }
            
            return isRaw 
                ? UnityEngine.Input.GetAxisRaw(axisName) 
                : UnityEngine.Input.GetAxis(axisName);
        }

        public bool TryCancel()
        {
            _cancelAxisValue = UnityEngine.Input.GetAxisRaw(CancelAxisName);
            
            if (_isCancelPressed == false && _cancelAxisValue > 0)
            {
                _isCancelPressed = true;
            }
            
            return _isCancelPressed;
        }
    }
}
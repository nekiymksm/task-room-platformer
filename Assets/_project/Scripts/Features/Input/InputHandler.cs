using System;
using _project.Scripts.CoreControl.Base;
using UnityEngine;

namespace _project.Scripts.Features.Input
{
    public class InputHandler : MonoBehaviour, IHandler
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string JumpAxisName = "Jump";
        private const string CancelAxisName = "Cancel";

        private bool _isJumpButtonHold;
        private bool _isCancelButtonHold;

        public float HorizontalAxisValue => UnityEngine.Input.GetAxis(HorizontalAxisName);

        public event Action JumpButtonDown;
        public event Action CancelButtonDown;

        private void FixedUpdate()
        {
            if (CheckButtonHold(UnityEngine.Input.GetAxis(JumpAxisName), ref _isJumpButtonHold))
            {
                JumpButtonDown?.Invoke();
            }

            if (CheckButtonHold(UnityEngine.Input.GetAxis(CancelAxisName), ref _isCancelButtonHold))
            {
                CancelButtonDown?.Invoke();
            }
        }

        public void Init(HandlersContainer handlersContainer)
        {
        }

        public void Run()
        {
        }

        private bool CheckButtonHold(float axisValue, ref bool isPressed)
        {
            if (isPressed)
            {
                if (axisValue <= 0)
                {
                    isPressed = false;
                }
                
                return false;
            }
            
            if (isPressed == false && axisValue > 0)
            {
                isPressed = true;
            }
            
            return isPressed;
        }
    }
}
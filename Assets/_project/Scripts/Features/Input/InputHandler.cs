using _project.Scripts.CoreControl.Base;

namespace _project.Scripts.Features.Input
{
    public class InputHandler : IHandler
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string JumpAxisName = "Jump";

        public void Init(HandlersContainer handlersContainer)
        {
        }

        public void Run()
        {
        }

        public float GetHorizontalAxisValue(bool isRaw = false)
        {
            return isRaw 
                ? UnityEngine.Input.GetAxisRaw(HorizontalAxisName) 
                : UnityEngine.Input.GetAxis(HorizontalAxisName);
        }
        
        public float GetJumpAxisValue(bool isRaw = false)
        {
            return isRaw 
                ? UnityEngine.Input.GetAxisRaw(JumpAxisName) 
                : UnityEngine.Input.GetAxis(JumpAxisName);
        }
    }
}
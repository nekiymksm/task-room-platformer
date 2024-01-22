using _project.Scripts.CoreControl.Handlers.Base;
using UnityEngine;

namespace _project.Scripts.CoreControl.Handlers
{
    public class InputHandler : IHandler
    {
        public float HorizontalAxis => Input.GetAxis("Horizontal");
        public float JumpAxis => Input.GetAxisRaw("Jump");
        
        public void Init(HandlersContainer handlersContainer)
        {
        }

        public void Run()
        {
        }
    }
}
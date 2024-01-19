using System.Collections.Generic;
using _project.Scripts.CoreControl.Handlers.Base;
using UnityEngine;

namespace _project.Scripts.CoreControl.Containers.Base
{
    public abstract class SceneContainer : MonoBehaviour, IContainer
    {
        public List<IHandler> Handlers { get; private set; }

        private void Awake()
        {
            Handlers = new List<IHandler>();

            foreach (var handler in Handlers)
            {
                handler.Init();
            }
        }

        private void Start()
        {
            foreach (var handler in Handlers)
            {
                handler.Run();
            }
        }
    }
}
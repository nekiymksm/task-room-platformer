using UnityEngine;

namespace _project.Scripts.ViewTracking
{
    public interface ITrackable
    {
        public Vector3 CurrentPosition { get; }
    }
}
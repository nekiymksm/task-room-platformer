using UnityEngine;

namespace _project.Scripts.Features.ViewTracking.Base
{
    public interface ITrackable
    {
        public Vector3 CurrentPosition { get; }
    }
}
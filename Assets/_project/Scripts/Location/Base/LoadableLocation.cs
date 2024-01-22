using UnityEngine;

namespace _project.Scripts.Location.Base
{
    public abstract class LoadableLocation : MonoBehaviour
    {
        [field: SerializeField] public Transform CharacterLoadPointTransform { get; private set; }
        [field: SerializeField] public Transform GroundLevelPointTransform { get; private set; }
        [field: SerializeField] public LocationBound EnterBound { get; private set; }
        [field: SerializeField] public LocationBound ExitBound { get; private set; }

        public void Set(Vector3 jointPosition)
        {
            jointPosition.x += Vector3.Distance(EnterBound.transform.position, ExitBound.transform.position) / 2;
            jointPosition.y = 0;
            transform.position = jointPosition;
        }
    }
}
using UnityEngine;

namespace Physics
{
    [System.Serializable]
    public class BounceData
    {
        [SerializeField] private float _force;
        [SerializeField] private float _maxHeight;

        public float Force { get => _force; }
        public float MaxHeight { get => _maxHeight; }
    }
}

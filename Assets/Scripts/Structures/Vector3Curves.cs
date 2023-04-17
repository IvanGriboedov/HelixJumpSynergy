using System;
using UnityEngine;

namespace Structures
{
    [System.Serializable]
    public class Vector3Curves
    {
        [SerializeField] private AnimationCurve _xCurve;
        [SerializeField] private AnimationCurve _yCurve;
        [SerializeField] private AnimationCurve _zCurve;

        public AnimationCurve XCurve { get => _xCurve; }
        public AnimationCurve YCurve { get => _yCurve; }
        public AnimationCurve ZCurve { get => _zCurve;  }
    }
}

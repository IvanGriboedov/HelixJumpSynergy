using UnityEngine;

namespace Input
{
    public readonly struct Swipe
    {
        public  Vector2 StartPos { get; }
        public Vector2 EndPos { get; }
        public Vector2 Delta { get; }
        public Swipe(Vector2 startPos, Vector2 endPos, Vector2 delta)
        {
            StartPos = startPos;
            EndPos = endPos;
            Delta = delta;
        }
        public Vector2 NormalizeDelta => Delta.normalized;
    }

}

using Physics.Ejection;
using Extensions;
using System.Collections;
using UnityEngine;

namespace Platforms.Parts
{
    public abstract class PlatformPart : MonoBehaviour
    {
        public void UnhookBy(EjectionSo ejection, Vector3 centerOfPlatform)
        {
            Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
            transform.ClearParent();
            rigidbody.detectCollisions = false;
            ejection.PushOut(rigidbody, centerOfPlatform);
        }
    }
}
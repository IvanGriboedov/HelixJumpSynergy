using System;
using UnityEngine;

namespace Tower
{
    public class TowerRotation : MonoBehaviour
    {
        [SerializeField] [Min(0.0f)] private float _rotationSpeed;

        private Quaternion _newRoationAngle;
        private void Update()
        {
            transform.rotation = CalculateRotation(Time.deltaTime * _rotationSpeed);
        }

        private Quaternion CalculateRotation(float rotationSpeed) => 
            Quaternion.Slerp(transform.rotation, _newRoationAngle, rotationSpeed);

        public void AddRotation(float xAxis)
        {
            Vector3 newEulerRotationAngle = transform.eulerAngles + Vector3.down * xAxis;
            _newRoationAngle = Quaternion.Euler(newEulerRotationAngle);
        }
    }
}

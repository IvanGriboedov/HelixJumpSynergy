using System.Collections;
using UnityEngine;
using Platforms;
namespace Ball
{
    public class BallCollisions : MonoBehaviour
    {
        [SerializeField] private BallBounce _bounce;
        [SerializeField] private BallParticles _particles;
        [SerializeField] private Transform _ball;


        private bool _collided;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out PlatformObstacle _))
            {
                Destroy();
                return;
            }

            if (_collided)
                return;

            _collided = true;
            _bounce.BounceOff(Vector3.up);
            _particles.EmitSpotParticles(other);
            _particles.EmitCollisionParticles(other);
        }
        private void OnCollisionExit(Collision collision)
        {
            _collided = false;
        }
        private void Destroy()
        {
            //effects
            _particles.EmitDestoryParticles(_ball.position);

            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ball
{
    public class BallParticles : MonoBehaviour
    {
        private const float SurfaceYOffset = 0.06f;

        [SerializeField] private ParticleSystem _collisionParticlesPrefab;
        [SerializeField] private ParticleSystem _spotParticlesPrefab;
        [SerializeField] private ParticleSystem _destroyParticlesPrefab;


        private ParticleSystem _collisionParticles;
        private void Start() =>
            _collisionParticles = Instantiate(_collisionParticlesPrefab);

        public void EmitCollisionParticles(Collision other)
        {
            Vector3 collisionPosition = other.contacts[0].point;

            _collisionParticles.transform.position = collisionPosition;
            _collisionParticles.Play();
        }
        public void EmitSpotParticles(Collision other)
        {
            Vector3 collisionPosition = other.contacts[0].point + Vector3.up * SurfaceYOffset;
            Instantiate(_spotParticlesPrefab, collisionPosition, Quaternion.identity, other.transform);
        }
        public void EmitDestoryParticles(Vector3 position) =>
            Instantiate(_destroyParticlesPrefab, position, Quaternion.identity);
    }

}

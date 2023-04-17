﻿using System.Collections;
using UnityEngine;
using Cinemachine;

namespace Ball
{
    public class BallDestroyer : MonoBehaviour
    {
        [SerializeField] private Transform _ball;
        [SerializeField] private BallParticles _particles;
        [SerializeField] private CinemachineImpulseSource _impulseSource;


        public void Destroy()
        {
            //effects
            _particles.EmitDestoryParticles(_ball.position);
            _impulseSource.GenerateImpulse();
            Destroy(_ball.gameObject);
        }
    }
}
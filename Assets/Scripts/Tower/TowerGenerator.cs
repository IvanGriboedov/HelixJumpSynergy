using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platforms;

namespace Tower
{
    public class TowerGenerator : MonoBehaviour
    {
        [SerializeField] private Platform _startPlatform;
        [SerializeField] private Platform _finishPlatform;
        [SerializeField] private Platform[] _platformVariants;

    }
}
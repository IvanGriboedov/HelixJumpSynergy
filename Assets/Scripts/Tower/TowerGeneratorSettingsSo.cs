using Extensions;
using Platforms;
using Structures;
using UnityEngine;

namespace Tower
{
    [CreateAssetMenu(fileName = "TowerGeneratorSettings", menuName = "ScriptableObjects/Tower/TowerGenerationSettings", order = 0)]
    public class TowerGeneratorSettingsSo : ScriptableObject
    {

        [SerializeField] [Min(0)] private int _platformVariantCount;
        [SerializeField] [Min(0.0f)] private float _offsetBetweenPlatforms;

        [SerializeField] private FloatRange _rotationRange;

        [Header("Platform Prefabs")]
        [SerializeField] private Platform _startPlatformPrefab;
        [SerializeField] private Platform _finishPlatformPrefab;
        [SerializeField] private Platform[] _platformVariantsPrefab;


        public int PlatformVariantCount  => _platformVariantCount; 
        public float OffsetBetweenPlatforms => _offsetBetweenPlatforms;
        public Platform StartPlatformPrefab => _startPlatformPrefab;
        public Platform FinishPlatformPrefab => _finishPlatformPrefab;

        public FloatRange RotationRange => _rotationRange;

        public Platform PlatformVariantPrefab() => _platformVariantsPrefab.Random();
    }
}
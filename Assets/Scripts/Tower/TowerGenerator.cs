using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platforms;
using Extensions;
using Structures;

namespace Tower
{
    public class TowerGenerator : MonoBehaviour
    {
        [SerializeField] private TowerGeneratorSettingsSo _towerGeneratorSettings;

        private FloatRange RotationRange => _towerGeneratorSettings.RotationRange;

        [Header("Tower")]
        [SerializeField] private Transform _tower;


        private void Start()
        {
            Generate(_towerGeneratorSettings, _tower);
        }
        private void Generate(TowerGeneratorSettingsSo generatorSettings, Transform tower)
        {
            List<Platform> spawnedPlatform = SpawnPlatforms(generatorSettings, out float offsetFromTop);
            FitTowerHeight(tower, offsetFromTop);
            spawnedPlatform.ForEach(platform => platform.transform.SetParent(tower));
        }
        private List<Platform> SpawnPlatforms(TowerGeneratorSettingsSo generatorSettings, out float offsetFromTop)
        {
            offsetFromTop = generatorSettings.OffsetBetweenPlatforms;
            const int startAndLastPlatofmr = 2;
            var spawnerPlatforms = new List<Platform>(generatorSettings.PlatformVariantCount + startAndLastPlatofmr);

            Platform startPlatform = Create(generatorSettings.StartPlatformPrefab, RotationRange, ref offsetFromTop);
            spawnerPlatforms.Add(startPlatform);

            for (int i = 0; i < generatorSettings.PlatformVariantCount; i++)
            {
                Platform platform = Create( generatorSettings.PlatformVariantPrefab(), RotationRange, ref offsetFromTop);
                spawnerPlatforms.Add(platform);
            }
            Platform finishPlatform = Create( generatorSettings.FinishPlatformPrefab, RotationRange, ref offsetFromTop);
            spawnerPlatforms.Add(finishPlatform);
            return spawnerPlatforms;
        }
        private Vector3 GetRandomYRotation(FloatRange rotationRange)
        {
            return rotationRange.Random * Vector3.up;
        }
        private Platform Create( Platform platformPrefab, FloatRange rotationRange, ref float offsetFromTop)
        {
            Platform createdPlatform = Instantiate(platformPrefab);

            Transform platformTransform = createdPlatform.transform;

            platformTransform.position = Vector3.down * offsetFromTop;
            platformTransform.eulerAngles = GetRandomYRotation(rotationRange);

            offsetFromTop += platformTransform.localScale.y + _towerGeneratorSettings.OffsetBetweenPlatforms;
            return createdPlatform;
        }
        private void FitTowerHeight(Transform tower, float height)
        {
            Vector3 originalSize = tower.localScale;
            float towerHeight = height / 2.0f;
            tower.localScale = new Vector3(originalSize.x, towerHeight, originalSize.z);
            tower.localPosition -= Vector3.up * towerHeight;
        }
    }
}
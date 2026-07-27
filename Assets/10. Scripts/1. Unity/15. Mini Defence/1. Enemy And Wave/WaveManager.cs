using System.Collections;
using UnityEngine;

namespace Study.MiniDefence
{
    public class WaveManager : MonoBehaviour
    {
        private WaveDef currentWave;
        private MapData currentMap;

        // WaveManager가 동작하기 위한 EntryPoint
        public void StartWave(WaveDef wave, MapData map)
        {
            currentWave = wave;
            currentMap = map;
            StartCoroutine(WaveCoroutine());
        }

        private void SpawnOne()
        {
            
        }
        
        private IEnumerator WaveCoroutine()
        {
            yield return new WaitForSeconds(1);
        }
        
        private void HandleGoalReached(Enemy enemy)
        {
            
        }
    }
}
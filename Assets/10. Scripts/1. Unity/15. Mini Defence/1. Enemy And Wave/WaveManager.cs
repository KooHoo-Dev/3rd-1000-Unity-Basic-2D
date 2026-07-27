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

        // Enemy 한 개체에 대한 스폰 처리 함수
        private void SpawnOne()
        {
            // Enemy 정보를 가지고 온다
            EnemyDef def = currentWave.Enemy;
            Enemy enemy = Instantiate(def.Prefab);
            enemy.Init(def, currentMap.GetWorldRoutePoints());
        }
        
        private IEnumerator WaveCoroutine()
        {
            Debug.Log("Starting wave");
            // 웨이브 정보에 따른 딜레이 처리
            yield return new WaitForSeconds(currentWave.Delay);

            // 웨이브 정보에 정의된 숫자만큼
            for (int i = 0; i < currentWave.Count; i++)
            {
                // 소환하고
                SpawnOne();
                Debug.Log("Spawning " + i + " of " + currentWave.Count + " enemies");
                // 웨이 정보에 정의된 간격(시간)만큼 대기한다
                yield return new WaitForSeconds(currentWave.Interval);
            }
            
            Debug.Log("Wave finished");
        }
        
        private void HandleGoalReached(Enemy enemy)
        {
            
        }
    }
}
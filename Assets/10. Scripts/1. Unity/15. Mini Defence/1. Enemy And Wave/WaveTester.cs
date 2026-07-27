using UnityEngine;

namespace Study.MiniDefence
{
    // Wave를 테스트 하는 객체
    // 개발할때 사용을 하며 실제 릴리즈된 내용에는 없다 
    
    public class WaveTester : MonoBehaviour
    {
        public WaveManager waveManager;
        public MapData map;
        
        // 작업하기 편하도록 인스펙터 수정가능한 데이터를 맹글어 둔다
        [SerializeField] private WaveDef waveDef;
        [SerializeField] private EnemyDef enemyDef;
        
        
    }
}
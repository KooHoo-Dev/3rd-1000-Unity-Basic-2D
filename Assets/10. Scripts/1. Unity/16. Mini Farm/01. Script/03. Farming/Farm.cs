using System.Collections.Generic;
using UnityEngine;

namespace Study.MiniFarm
{
    // 복잡성이 높은 주요 클래스들을 개발할때는
    // 애초부터 로그를 찍을 생각으로 검증하는 하나의 단위를 만들면서 개발하는게
    // 속도가 더 빠릅니다
    
    // 농사 행동(4가지 행동 포함)을 시도한 결과
    // 를 데이터 정의를 해놓습니다.
    public enum FarmResult
    {
        Ok,
        WrongTile,          // 그 행동을 할 수 없는 종류의 칸 일 때
        AlreadyTilled,      // 이미 갈아둔 밭(타일)이다 : Till의 결과
        AlreadyPlanted,     // 이미 뭔가 심어져 있다    : Sow의 결과중 하나
        NoCrop,             // 있는게 없다. 물주기 or 수확의 결과
        AlreadyWatered,       // 이미 물을 줬다
        AlreadyGrown,       // 다 자라서 물 줄 필요가 없음
        NotGrown,           // 아직 덜 자라서 수확 불가능
        NoSeed,             // 씨앗이 없어서 심을게 없음
    }

    public static class FarmResultText
    {
        public static string Of(FarmResult result)
        {
            return result switch
            {
                FarmResult.Ok => "됐다",
                FarmResult.WrongTile => "여기서는 할 수 없다",
                FarmResult.AlreadyTilled => "이미 갈아 둔 밭이다",
                FarmResult.AlreadyPlanted => "이미 심겨 있다",
                FarmResult.NoCrop => "심긴 것이 없다",
                FarmResult.AlreadyWatered => "오늘은 이미 물을 줬다",
                FarmResult.AlreadyGrown => "다 자랐다. 거두면 된다",
                FarmResult.NotGrown => "아직 덜 자랐다",
                FarmResult.NoSeed => "씨앗이 없다. 상점에서 사야 한다",
                _ => "알 수 없는 에러",
            };
        }
    }
    
    
    
    // 밭에서 벌어지는 모든 일을 맡는다. 씬에 하나만 놓고 씁니다
    // 역할
    // - 갈고
    // - 심고
    // - 물주고
    // - 수확하고
    // 농장을 돌리는 게임 로직의 모음집 역할을 하는 클래스 입니다
    // 모든 작물, 그리드, 타일에 배치될 프롭 들을 총 관리 한다.
    // (원래는 쪼개져있었다)
    
    // 기능구현을 다 하고 Farmer랑 연결만 시켜주면 된다
    
    public class Farm : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private PathFinder pathFinder;

        [Header("Crops")] 
        [SerializeField] private Crop[] cropPrefabs;
        // 좌표와 작물의 정보를 저장하는 딕셔너리
        private readonly Dictionary<Vector2Int, Crop> crops = new();
        // 작물이 심어지면 해당칸의 TitleType을 덮어씌워 주는 용도
        private const TileType BLOCKED_TYPE = TileType.Rock;

        private WorldClock clock;
        
        // 아래 두개는 추후 수정
        private FarmGrid Grid => pathFinder.Grid;
        private MapData MapData => pathFinder.MapData;

        # region 네 가지 행동

        // 밭을 가는 해동. (흙 -> 밭)
        public void Till()
        {
            
        }

        // 씨앗을 심는 행동
        public void Sow()
        {
            
        }

        // 물을 주는 행동
        public void Water()
        {
            
        }
        
        // 다 자란 작물을 거둔다
        public void Harvest()
        {
            
        }
        
        # endregion
        
        
        
        private void RefreshOverLay(Vector2Int coord)
        {
            
        }
    }
}
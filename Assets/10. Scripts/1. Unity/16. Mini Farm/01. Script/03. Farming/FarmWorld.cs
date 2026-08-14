using System.Threading.Tasks;
using Jay;
using Unity.VisualScripting;
using UnityEngine;

namespace Study.MiniFarm
{
    // 맵, 그리드, 농사시스템 초기화 담당
    // 하지만 길찾기, 표 정보, 농사 규칙은 일체 관리하지 않음
    public class FarmWorld : SingletonBase<FarmWorld>
    {
        [field: SerializeField] public MapData MapData { get; private set; }
        [field: SerializeField] public MapLoader MapLoader { get; private set; }
        public FarmGrid Grid { get; private set; }
        public bool IsReady => Grid != null;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            BuildWorld();
        }

        private async void BuildWorld()
        {
            await DataManager.Instance.EnsureLoadedAsync();
            MapLoader = GetComponent<MapLoader>();
            MapData = MapLoader.LoadOrNull();
            
            Farm farm = FindAnyObjectByType<Farm>();
            if (farm == null)
            {
                Debug.LogError($"[FarmWorld] Farm이 없습니다.");
                return;
            }

            farm.Init(MapData, Grid);
            PathFinder pathFinder = FindAnyObjectByType<PathFinder>();
            pathFinder.Init(Grid);
            
            FarmerCommander commander = FindAnyObjectByType<FarmerCommander>();
            commander.Init(pathFinder);
            Task.Delay(1000);
        }
    }
}
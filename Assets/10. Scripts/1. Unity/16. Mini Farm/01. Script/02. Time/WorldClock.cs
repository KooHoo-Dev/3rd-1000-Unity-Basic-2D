using System;
using Jay;
using UnityEngine;

namespace Study.MiniFarm
{
    // 농장 안에서 흐르는 시계. 하루를 굴리고, 멈추고, 빨리 감는다.
    // 이 게임에는 시계가 두 개 있습니다.
    // - 게임 시간(WorldClock)      : 작물 성장, 농부 이동, 시세 갱신
    // - 실제 시간(Engine, Device)  : UI, 커서, 카메라, 메뉴 등
    
    // 보통 일시정지가 있는 게임들은 엔진의 시간을 직접 사용하지 않고
    // 따로 정의를 해줍니다.
    // 이럴경우, 아래와 같은 개발 규칙이 추가됩니다.
    // - 게임 로직은 Time.deltaTime을 쓰지 않는다. 대신 WorldClock의 DeltaTime을 사용한다
    public class WorldClock : SingletonBase<WorldClock>
    {
        [Header("Settings")] 
        [SerializeField] private float tickInterval = 1f; // 알림 주기 역할을 하는 필드

        // 며칠째인가. 1일차부터 시작한다
        public int Day { get; private set; } = 1;
        // 하루 안에서 얼마나 진행되었는지. 0이 아침, 1이 밤
        public float TimeOfDay { get; private set; } = 1;
        // 지금 고른 배속 단계. int인 이유는 외부파일의 배열 데이터 인덱스로 사용함
        public int ScaleStep { get;private set; } = 1;

        public float Scale => scale; 
        private float scale = 1f; // GameSetting으로 추후 수정
        
        public bool IsPaused => Scale <= 0f;

        // 게임 로직이 써야 하는 시간 간격
        // : Time.deltaTime이 아니라 unscaledDeltaTime를 사용.
        //  Time.timeScale은 건드리지 않기로 했으므로, 누군가 그것을
        //  바꾸더라도 흔들리지 않는 시계가 필요하다.
        //  배속은 우리가 직접 연산한다.
        public float DeltaTime => Time.unscaledDeltaTime * Scale;

        // 마지막날 계산용 필드
        public bool IsFinished { get; private set; } = false;

        #region Events(델리게이트)
        
        public event Action OnTick; // 게임시간이 tickInterval 만큼 흐를때마다               
        public event Action<int> OnDayStarted;      // 하루의 시작(새 날이 밝았다!)
        public event Action<int> OnDayEnded;        // 하루의 종료
        public event Action<bool> OnPauseChanged;   // Pause의 상태 변화

        #endregion
    }

}


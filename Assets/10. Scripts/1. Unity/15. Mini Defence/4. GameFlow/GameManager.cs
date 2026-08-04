using System;
using Jay;
using Jay.FSM;

namespace Study.MiniDefence
{
    // 현재 우리가 만들고 있는 디펜스게임은 몇몇 큰 흐름이 있습니다
    // 1. Ready : 유닛 구매, 판매 기능등이 활성화 됩니다.
    //            게임을 시작하거나, 웨이브를 클리어하면 진입
    // 2. InWave : 웨이브를 진행하는 단계.
    //           Ready상태에서 버튼을 눌러서 진입할 수 있습니다
    // 3. Defeat : 체력이 다 없어져서 패배하는 단계 입니다.
    // 4. Victory : 3웨이브를 클리어하면 진입하는. 승리 단계
    
    public class GameManager : SingletonBase<GameManager>
    {
        # region 상태 관련 필드
        
        private StateMachine<IGameFlowState> machine = new();

        // 준비상태는 남은 준비 시간을 물어봐야하 하므로 따로 들고 있는다.
        private ReadyState readyState = new();

        public IGameFlowState State => machine.CurrentState;
        public GameStateId StateId => machine.CurrentState.Id;

        // 남은 준비 시간을 반환합니다. Ready상태가 아니라면 무조건 0을 반환합니다.
        public float PrepRemaining
            => machine.IsCurrent<ReadyState>() ? readyState.Remaining : 0f;
        
        public event Action<IGameFlowState> StateChanged;
        
        # endregion
        
        // 목숨
        public int Lives { get; private set; }
        public event Action<int> LivesChanged;

        protected override void OnInitialize()
        {
            base.OnInitialize();
        }

        private void Update()
        {
            throw new NotImplementedException();
        }

        private void OnEnable()
        {
            throw new NotImplementedException();
        }

        private void OnDisable()
        {
            throw new NotImplementedException();
        }
    }
}
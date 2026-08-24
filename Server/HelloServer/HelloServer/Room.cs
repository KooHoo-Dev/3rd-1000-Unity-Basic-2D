using System.Net.WebSockets;

namespace HelloServer;

// 방 하나. 방에 있는 사람들을 들고 있다가
// 메세지를 전달해 준다.
// 방의 기능은 아래와 같습니다
// 1. 들어온다 : JoinAsync
// 2. 말한다   : ReceiveLoopAsync => 결국 요게 채팅임
// 3. 나간다   : LeaveAsync
// 4. 뿌린다   : BroadcastStateAsync

// Room은 메시지를 무리는 법만 알고
// 언제 뿌릴지는 결정하지 않습니다. 

public class Room
{
    // 접속자 한 명.
    private class Member
    {
        public User User;
        public WebSocket Socket;

        // 원래는 벡터로 Position으로 묶어서 사용하는게 좋습니다.
        // 님들이 개발할때는 그렇게 하세여
        public float X;
        public float Y;

        public int MovesSinceLog;
        
        // DateTime?
        // : 날짜랑 시간을 표현하고 조작할 때 사용하는 구조체 입니다.
        //  DateTime.Now : 현재 지역 시간을 나타낼 수 있ㅅ브니다
        //  DateTime.UtcNow : 협정 세계시(영국 본초 자오선(?))
        // 출력 서식을 따로 지정할 수 있습니다. 그거는 MS 홈페이지 가서 보세요
        public DateTime LastLogAt;
        
        // 보낼때 여러메시지를 동시에 보내지 않기 위에
        // 사람(멤버)마다 Gate를 하나씩 두고 한번에 하나씩 보내기 위해
        // 사용하는 클래스. (비동기에서 lock처리가 안되서 사용)
        // 읽는것은 여러 쓰레드에서 읽을 수 있는데 사용(Write)는
        // 하나의 쓰레드에서만 온전히 돌아갈 수 있도록 하게 해주는 클래스
        public readonly SemaphoreSlim SendLock 
            = new SemaphoreSlim(1, 1);
    }
    
    
}
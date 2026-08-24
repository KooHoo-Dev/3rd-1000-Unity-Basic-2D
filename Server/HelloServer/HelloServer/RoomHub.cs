using System.Net.WebSockets;

namespace HelloServer;

// 여러개의 방들을 관리하는 클래스.
// 코드로 방을 찾아주고, 빈 방을 치운다, 

public class RoomHub
{
    // 방 하나와 그 방에 들어가겠다고 한 사람의 수
    // 방을 만들기 전에(방을 찾은 뒤) 실제로 방이 생성 될때까지는
    // 시간이 조금 걸립니다. 그 사이에 어떤 유저가 나가게되면
    // 바로 비어버리게 되니까 별도의 클래스를 만들어서 룸자체를 관리해줍니다. 
    // (룸을 한번 감싸는 거임)
    private class Entry
    {
        public Room Room;
        public int Users;
    }

    private readonly Dictionary<string, Entry> rooms = new();

    private readonly int broadcastPerSecond;
    private readonly int logMovesPerSecond;

    private readonly object gate = new object();

    private int lastId;

    public RoomHub(int broadcastPerSecond, int logMovesPerSecond)
    {
        this.broadcastPerSecond = broadcastPerSecond;
        this.logMovesPerSecond = logMovesPerSecond;
    }

    #region 방 관리 함수들(찾기, 지우기)

    // 방을 먼저 찾아보고, 없다면 만든다.
    private Room Enter(string code)
    {
        // lock(매개변수)?
        // : 해당 영역에 들어갈 수 있는 녀석들은. gate를 참조하고있는
        //  녀석들만 들어올 수 있습니다. 다른 녀석을 못들어옴.
        //  lock이라는게 걸리면 gate가 키의 역할을 한다고 생각하시면 됩니다.
        //  (gate를 알고있는 갈래의 객체들만 들어옴)
        //  안전한 처리를 위해 사용을 합니다.
        
        //  실제 컴퓨터에서 처리를 할때 해당 영역을 처음부터 끝까지
        //  처리함을 보장하는 장치 입니다. (이렇게 알고있으면 됩니다)
        //  매개변수에 객체는 private readonly로 하게되면
        //  나만 알고있는 키를 사용해서 더 안전하게 사용 할 수있습니다.
        //  (this로 걸게되면 이 클래스가 public이니까 외부에서도
        //  잠글 수 있음)
        lock (gate)
        {
            if (rooms.TryGetValue(code, out Entry entry) == false)
            {
                entry = new Entry()
                    {Room = new Room(code, logMovesPerSecond), Users = 0};
                rooms.Add(code, entry);
                Console.WriteLine($"[{code}] 방을 열었다. 총 방의 개수 : {rooms.Count}");
            }

            entry.Users++;
            return entry.Room;
        }
    }

    // 방을 떠나고, 아무도 없으면 방을 지운다.
    private void Leave(string code)
    {
        lock (gate)
        {
            // 예외 처리 한번 해준다
            if (rooms.TryGetValue(code, out Entry entry) == false) return;
            entry.Users--;
            if (entry.Users > 0) return;
            rooms.Remove(code);
            Console.WriteLine($"[{code}] 아무도 없어서 방을 지움. 총 방의 개수 {rooms.Count}");
        }
    }

    #endregion

    // 아래의 비동기 함수는 한 사람의 접속부터 끊김까지
    // 방을 찾아 넘기고, 끝나면 뒷정리하는 함수 입니다.
    // (RoomHub -> Room의 함수를 호출)
    public async Task HandleAsync(string code, 
        WebSocket socket, CancellationToken token)
    {
        
    }

    // 보든 방에 시간(일정 주기)별로 틱을 관리하는 함수 입니다.
    // 틱을 관리하면서 Task.WhenAll을 통해서 방의 메시지들을 방송합니다.
    // (RoomHub -> Room의 함수를 호출)
    public async Task BroadcastLoopAsync(CancellationToken token)
    {
        
    }

    // 방 코드를 정규화 하는 유틸 함수입니다.
    // 빈 문자처리, 특수문자 처리등을 합니다.
    public static string Normalize(string raw)
    {
        
    }
}
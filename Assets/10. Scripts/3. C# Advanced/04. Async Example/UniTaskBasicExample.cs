using System;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Study.Utilities;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

namespace Study.Async
{
    // UniTask가 Task 대비 무엇을 더 주는지 하나씩 테스트 해보는 예제
    public class UniTaskBasicExample : MonoBehaviour
    {
        public float waitSeconds = 2f;
        public int waitFrame = 60;
        public float spinSpeed = 180f;
        public bool isReady = false;

        private CancellationToken destroyToken;

        private void Awake()
        {
            // destroyCancellationToken이랑 GetCancellationTokenOnDestroy() 같습니다.
            // (destroyCancellationToken 요게 Unity6에서 나왔음. 선택은 취향)
            destroyToken = this.GetCancellationTokenOnDestroy();
        }

        private void Update()
        {
            transform.Rotate(0f,0f,spinSpeed * Time.deltaTime);

            if (SimpleInput.GetKeyDown(Key.T)) ToggleTimeScale();
            
            // UniTaskVoid 형태에는 Forget을 입력해서 문법적처리로 에러로그를 방지했었음
            if (SimpleInput.GetKeyDown(Key.Digit1)) DelayGameTimeAsync().Forget();
            if (SimpleInput.GetKeyDown(Key.Digit2)) WaitUntilReady().Forget();
            if (SimpleInput.GetKeyDown(Key.Digit3)) DelayFrame().Forget();
        }

        private bool timeToggle = true;
        private void ToggleTimeScale()
        {
            timeToggle = !timeToggle;
            Time.timeScale = timeToggle ? 1f : 0f;
        }
        
        private async UniTaskVoid DelayGameTimeAsync()
        {
            Debug.Log($"[UniTaskBasicExample] " +
                      $"DelayGameTimeAsync : {waitSeconds}초 대기");
            await UniTask.Delay(Mathf.RoundToInt(waitSeconds * 1000)
                , DelayType.Realtime 
                , cancellationToken: destroyToken); 
            // (매개변수명: 인자) 요거는 여러 매개변수중에 특정 매개변수를
            // 이름으로 지정해서 넘길 인자를 정해주는 문법입니다.
            
            // DeltaTime : 유니티의 Time.timeScale에 영향을 받습니다
            // UnscaledDeltaTime : timescale 영향을 안받습니다
            // Realtime : 현실 시계를 기준으로 동작합니다. (앱 포커스에 영향을 받지 않습니다)
            
            Debug.Log($"[UniTaskBasicExample] DelayGameTimeAsync : 끝!");
        }

        private async UniTaskVoid WaitUntilReady()
        {
            Debug.Log($"[UniTaskBasicExample] WaitUntilReady : isReady 켜질때까지 대기");
            
            await UniTask.WaitUntil(() => isReady, cancellationToken: destroyToken);
            Color newColor = new Color(Random.value, Random.value, Random.value);
            GetComponent<SpriteRenderer>().color = newColor;
            // "() => isReady" 람다식이 조건문이 되는겁니다.
            // 결국 isReady가 True가 되면 대기가 완료 되는 로직이 됩니다.
            Debug.Log($"[UniTaskBasicExample] WaitUntilReady : isReady 켜짐");
        }
        
        private async UniTaskVoid DelayFrame()
        {
            Debug.Log($"[UniTaskBasicExample] DelayFrame");
            
            int beforeFrame = Time.frameCount;
            float temp = spinSpeed;
            spinSpeed = 0f;
            
            await UniTask.DelayFrame(waitFrame, cancellationToken: destroyToken);

            spinSpeed = temp;
            
            Debug.Log($"[UniTaskBasicExample] DelayFrame : {Time.frameCount - beforeFrame}," +
                      $"beforeFrame :  {beforeFrame}");
        }
    }
}
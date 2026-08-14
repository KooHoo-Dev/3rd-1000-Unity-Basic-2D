
using System.Collections;
using System.Threading.Tasks;
using Study.Utilities;
using UnityEngine;

public class Note : MonoBehaviour
{
    private async void Start()
    {
        Debug.Log("비동기 함수 시작!");
        await Task.Delay(5000);
        Debug.Log("await Task.Delay(5000);");
        
        int resultA = await Delay(5000);
        Debug.Log($"resultA = {resultA}");
        
        int resultB = await Delay(3000);
        Debug.Log($"resultB = {resultB}");
        
        int resultC = await Delay(7000);
        Debug.Log($"resultC = {resultC}");
        
    }

    private async Task<int> Delay(int milliseconds)
    {
        await Task.Delay(milliseconds);
        return milliseconds;
    }
}

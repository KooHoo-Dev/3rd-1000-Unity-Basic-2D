
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Study.Utilities;
using UnityEngine;

public class Note : MonoBehaviour
{
    private void Start()
    {
        //(float x, float y, float z) position = (10f,10f,10f);
        //Debug.Log($"{position.x}, {position.y}, {position.z}");

        //position.x = 390f;
        var position = Test();
        position.x = 300;
        Debug.Log($"{position.x}, {position.y}, {position.z}");
    }

    public (float x, float y, float z) Test()
    {
        return (10f, 10f, 10f);
    }
}

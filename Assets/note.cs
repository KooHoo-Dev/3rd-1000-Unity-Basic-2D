


using System;
using System.Collections.Generic;
using Study.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

public class Note : MonoBehaviour
{
    private string[] leaders = new[] { "이찬영", "채경희", "백성현", "홍산", "이강민" };
    private List<string> bucket = new List<string>();
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bucket.AddRange(leaders);

            while (bucket.Count > 0)
            {
                int rand = Random.Range(0, bucket.Count);
                Debug.Log(bucket[rand]);
                bucket.RemoveAt(rand);
            }
        }
    }
}

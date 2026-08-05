


using System;
using Study.Utilities;
using UnityEngine;

public class Note : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        var input = SimpleInput.GetMoveAxisRaw();
        anim.SetFloat("DirX", input.x);
        anim.SetFloat("DirY", input.y);

        if (input.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
    }
}

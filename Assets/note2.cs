using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class note2 : MonoBehaviour
{
    public TMP_Text hpText;

    private void Start()
    {
        
    }
    
    private void SetHpText(float hp)
    {
        hpText.SetText(hp.ToString());
    }
}

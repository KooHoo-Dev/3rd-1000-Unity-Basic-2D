using System;
using UnityEngine;

namespace Study.MiniDefence
{
    public class UnitTester : MonoBehaviour
    {
        private UnitTable unitTable;

        private void Start()
        {
            unitTable = new UnitTable();
            unitTable.Load();
            
            Debug.Log($"UnitTable loaded {unitTable.Count}");
        }
    }
}
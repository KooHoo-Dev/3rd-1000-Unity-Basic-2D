using System;
using Jay;
using UnityEngine;

namespace Study.MiniDefence
{
    public class EconomyManager : SingletonBase<EconomyManager>
    {
        public event Action<int> MineralsChanged;

        public bool CanAfford(int selectedDefCost)
        {
            return true;
        }
    }
}
using Study.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Study.MiniFarm
{
    public class CropTester : MonoBehaviour
    {
        public Crop[] crops;
        
        // Update is called once per frame
        void Update()
        {
            if (SimpleInput.GetKeyDown(Key.Digit1))
            {
                foreach (var crop in crops)
                {
                    crop.Water();
                }
            }
        }
    }

}


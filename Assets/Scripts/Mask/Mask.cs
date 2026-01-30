using Managers;
using UnityEngine;
using Utilities;

namespace Mask {
    public class Mask : MonoBehaviour {
        [Header("Refs")]
        [SerializeField] private SpriteRenderer spriteRenderer; 
        [SerializeField] private GameManager gameManager;

        public string CorrectColorName { get; set; }
        
        public void SetSpriteColor(EnumBank.ColorOptions colorOption) {
            spriteRenderer.color = gameManager.ColorDataList[colorOption].color;
            CorrectColorName = gameManager.ColorDataList[colorOption].displayName;
        }
    }
}
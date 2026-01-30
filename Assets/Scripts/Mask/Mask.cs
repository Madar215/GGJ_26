using Managers;
using UnityEngine;
using Utilities;

namespace Mask {
    public class Mask : MonoBehaviour {
        [Header("Refs")]
        [SerializeField] private SpriteRenderer bodySpriteRenderer; 
        [SerializeField] private SpriteRenderer borderSpriteRenderer;
        [SerializeField] private GameManager gameManager;

        public string CorrectColorName { get; set; }
        
        public void SetSpriteColor(EnumBank.ColorOptions colorOption) {
            bodySpriteRenderer.color = gameManager.ColorDataList[colorOption].color;
            CorrectColorName = gameManager.ColorDataList[colorOption].displayName;
        }

        public void SetFrameColor(EnumBank.ColorOptions colorOption) {
            borderSpriteRenderer.color = gameManager.ColorDataList[colorOption].color;
        }

        public void SetBodySprite(Sprite sprite) {
            bodySpriteRenderer.sprite = sprite;
        }
    }
}
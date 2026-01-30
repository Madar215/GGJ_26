using TMPro;
using UnityEngine;
using Utilities;

namespace Mask {
    public class ColorButton : MonoBehaviour {
        [Header("Refs")]
        [field: SerializeField] public TextMeshProUGUI text;
        
        [Header("Settings")]
        [SerializeField] private EnumBank.ButtonsPosition pos;

        public void SetColor(Color color) {
            text.color = color;
        }

        public void SetColorName(string colorName) {
            text.SetText(colorName);
        }

        public bool IsSameColorOption(EnumBank.ButtonsPosition buttonPos) {
            return buttonPos == pos;
        }
    }
}
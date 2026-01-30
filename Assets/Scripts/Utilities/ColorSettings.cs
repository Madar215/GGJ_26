using System.Collections.Generic;
using UnityEngine;

namespace Utilities {
    [CreateAssetMenu(fileName = "ColorSettings", menuName = "Settings/ColorOptions")]
    public class ColorSettings : ScriptableObject {
        public List<ColorData> colorList = new();
    }
}
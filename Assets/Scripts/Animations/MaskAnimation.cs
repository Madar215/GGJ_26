using System.Collections.Generic;
using UnityEngine;

namespace Animations {
    [CreateAssetMenu(fileName = "Mask Animation", menuName = "Animation SO", order = 0)]
    public class MaskAnimation : ScriptableObject {
        public List<Sprite> spritesToAnimate;
    }
}
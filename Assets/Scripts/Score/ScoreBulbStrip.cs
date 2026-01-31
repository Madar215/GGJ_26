using UnityEngine;

namespace Score {
    public class ScoreBulbStrip : MonoBehaviour
    {
        [Header("Bulbs (left to right)")]
        [SerializeField] private SpriteRenderer[] bulbs;

        [Header("Sprites")]
        [SerializeField] private Sprite offSprite;
        [SerializeField] private Sprite onSprite;

        public void SetScore(int score) {
            if (bulbs == null) return;

            for (int i = 0; i < bulbs.Length; i++) {
                if (!bulbs[i]) continue;
                bulbs[i].sprite = i < score ? onSprite : offSprite;
            }
        }

        public void ResetAll() {
            SetScore(0);
        }
    }
}

using System.Collections.Generic;
using Managers;
using UnityEngine;
using Utilities;

namespace Animations {
    public class AnimationMaker : MonoBehaviour {
        [Header("Refs")]
        [SerializeField] private RandomManager randomManager;
        [SerializeField] private SpriteRenderer borderSpriteRenderer;
        
        [Header("Settings")]
        [SerializeField] private float fpsCount = 0.1f;
        [SerializeField] private float waitBetweenAnimations = 1f;
        [SerializeField] private EnumBank.Players player;
        
        private List<Sprite> _spritesToAnimate = new();
        
        private int _curFrame;
        private CountdownTimer _fpsTimer;
        private CountdownTimer _waitBetweenAnimationsTimer;

        private void OnEnable() {
            randomManager.OnAnimationChange += ChangeMaskAnimation;
        }

        private void OnDisable() {
            randomManager.OnAnimationChange -= ChangeMaskAnimation;
        }

        private void Start() {
            _waitBetweenAnimationsTimer = new CountdownTimer(waitBetweenAnimations);
            _fpsTimer = new CountdownTimer(fpsCount);
            _fpsTimer.Start();
        }

        private void Update() {
            _fpsTimer.Tick(Time.deltaTime);
            _waitBetweenAnimationsTimer.Tick(Time.deltaTime);

            if (_waitBetweenAnimationsTimer.IsRunning) return;

            if (_fpsTimer.IsRunning) return;
            
            if (_curFrame >= _spritesToAnimate.Count) {
                _curFrame = 0;
                _waitBetweenAnimationsTimer.Start();
            }
            
            borderSpriteRenderer.sprite = _spritesToAnimate[_curFrame];
            ++_curFrame;
            
            _fpsTimer.Start();
        }

        private void ChangeMaskAnimation(MaskAnimation maskAnim, EnumBank.Players p) {
            if (p != player) return;
            
            _spritesToAnimate = maskAnim.spritesToAnimate;
        }
    }
}

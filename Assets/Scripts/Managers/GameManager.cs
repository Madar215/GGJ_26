using System;
using System.Collections.Generic;
using Input;
using UnityEngine;
using UnityEngine.Events;
using Utilities;

namespace Managers {
    public class GameManager : MonoBehaviour {
        [Header("Refs")]
        [SerializeField] private UiManager uiManager;
        [SerializeField] private Mask.Mask p1Mask;
        [SerializeField] private Mask.Mask p2Mask;
        [SerializeField] private InputReader inputReader;
        [SerializeField] private ColorSettings colorSettings;

        [Header("Settings")] 
        [SerializeField] private float startOverTime = 3f;
        
        public Dictionary<EnumBank.ColorOptions, ColorData> ColorDataList = new();
        
        private bool _canInput = true;
        
        private int _p1ScoreNum;
        private int _p2ScoreNum;

        private CountdownTimer _startOverTimer;
        
        // Events
        public event UnityAction OnRoundStart;
        public event UnityAction<int, int> OnRoundEnd;

        private void Awake() {
            _startOverTimer = new CountdownTimer(startOverTime);
        }

        private void Update() {
            _startOverTimer.Tick(Time.deltaTime);
        }

        private void OnEnable() {
            // Timers
            _startOverTimer.OnTimerStop += StartRound;
            // P1
            inputReader.P1TopLeft += OnP1TopLeft;
            inputReader.P1TopCenter += OnP1TopCenter;
            inputReader.P1TopRight += OnP1TopRight;
            inputReader.P1BottomLeft += OnP1BottomLeft;
            inputReader.P1BottomCenter += OnP1BottomCenter;
            inputReader.P1BottomRight += OnP1BottomRight;
            // P2
            inputReader.P2TopLeft += OnP2TopLeft;
            inputReader.P2TopCenter += OnP2TopCenter;
            inputReader.P2TopRight += OnP2TopRight;
            inputReader.P2BottomLeft += OnP2BottomLeft;
            inputReader.P2BottomCenter += OnP2BottomCenter;
            inputReader.P2BottomRight += OnP2BottomRight;
        }

        private void OnDisable() {
            // Timers
            _startOverTimer.OnTimerStop -= StartRound;
            // P1
            inputReader.P1TopLeft -= OnP1TopLeft;
            inputReader.P1TopCenter -= OnP1TopCenter;
            inputReader.P1TopRight -= OnP1TopRight;
            inputReader.P1BottomLeft -= OnP1BottomLeft;
            inputReader.P1BottomCenter -= OnP1BottomCenter;
            inputReader.P1BottomRight -= OnP1BottomRight;
            // P2
            inputReader.P2TopLeft -= OnP2TopLeft;
            inputReader.P2TopCenter -= OnP2TopCenter;
            inputReader.P2TopRight -= OnP2TopRight;
            inputReader.P2BottomLeft -= OnP2BottomLeft;
            inputReader.P2BottomCenter -= OnP2BottomCenter;
            inputReader.P2BottomRight -= OnP2BottomRight;
        }

        private void Start() {
            foreach (var colorData in colorSettings.colorList) {
                ColorDataList.TryAdd(colorData.option, colorData);
            }
            OnRoundStart?.Invoke();
        }

        private void StartRound() {
            OnRoundStart?.Invoke();
            
            // Can read input now
            _canInput = true;
        }

        private void CheckWinForP1(bool checkColor) {
            
            if (checkColor) {
                _p1ScoreNum++;
            }
            else {
                _p2ScoreNum++;
            }

            OnRoundEnd?.Invoke(_p1ScoreNum, _p2ScoreNum);
            _startOverTimer.Start();
        }
        
        private void CheckWinForP2(bool checkColor) {
            if (checkColor) {
                _p2ScoreNum++;
            }
            else {
                _p1ScoreNum++;
            }

            OnRoundEnd?.Invoke(_p1ScoreNum, _p2ScoreNum);
            _startOverTimer.Start();
        }
        
        #region Inputs Functions

        // P1
        private void OnP1TopLeft() {
            if (!_canInput) return;
            _canInput = false;
            var checkColor = uiManager.CheckButtonPressed(EnumBank.Players.P1, EnumBank.ButtonsPosition.TopLeft, p1Mask.CorrectColorName);
            CheckWinForP1(checkColor);
        }

        private void OnP1TopCenter() {
            if (!_canInput) return;
            _canInput = false;
            var checkColor = uiManager.CheckButtonPressed(EnumBank.Players.P1, EnumBank.ButtonsPosition.TopCenter, p1Mask.CorrectColorName);
            CheckWinForP1(checkColor);
        }

        private void OnP1TopRight() {
            if (!_canInput) return;
            _canInput = false;
            var  checkColor = uiManager.CheckButtonPressed(EnumBank.Players.P1, EnumBank.ButtonsPosition.TopRight, p1Mask.CorrectColorName);
            CheckWinForP1(checkColor);
        }

        private void OnP1BottomLeft() {
            if (!_canInput) return;
            _canInput = false;
            var checkColor = uiManager.CheckButtonPressed(EnumBank.Players.P1, EnumBank.ButtonsPosition.BottomLeft, p1Mask.CorrectColorName);
            CheckWinForP1(checkColor);
        }

        private void OnP1BottomCenter() {
            if (!_canInput) return;
            _canInput = false;
            var checkColor = uiManager.CheckButtonPressed(EnumBank.Players.P1, EnumBank.ButtonsPosition.BottomCenter, p1Mask.CorrectColorName);
            CheckWinForP1(checkColor);
        }

        private void OnP1BottomRight() {
            if (!_canInput) return;
            _canInput = false;
            var checkColor = uiManager.CheckButtonPressed(EnumBank.Players.P1, EnumBank.ButtonsPosition.BottomRight, p1Mask.CorrectColorName);
            CheckWinForP1(checkColor);
        }
        // P2
        private void OnP2TopLeft() {
            if (!_canInput) return;
            _canInput = false;
            var checkColor = uiManager.CheckButtonPressed(EnumBank.Players.P2, EnumBank.ButtonsPosition.TopLeft, p2Mask.CorrectColorName);
            CheckWinForP2(checkColor);
        }

        private void OnP2TopCenter() {
            if (!_canInput) return;
            _canInput = false;
            var checkColor = uiManager.CheckButtonPressed(EnumBank.Players.P2, EnumBank.ButtonsPosition.TopCenter, p2Mask.CorrectColorName);
            CheckWinForP2(checkColor);
        }

        private void OnP2TopRight() {
            if (!_canInput) return;
            _canInput = false;
            var checkColor = uiManager.CheckButtonPressed(EnumBank.Players.P2, EnumBank.ButtonsPosition.TopRight, p2Mask.CorrectColorName);
            CheckWinForP2(checkColor);
        }

        private void OnP2BottomLeft() {
            if (!_canInput) return;
            _canInput = false;
            var checkColor = uiManager.CheckButtonPressed(EnumBank.Players.P2, EnumBank.ButtonsPosition.BottomLeft, p2Mask.CorrectColorName);
            CheckWinForP2(checkColor);
        }

        private void OnP2BottomCenter() {
            if (!_canInput) return;
            _canInput = false;
            var checkColor = uiManager.CheckButtonPressed(EnumBank.Players.P2, EnumBank.ButtonsPosition.BottomCenter, p2Mask.CorrectColorName);
            CheckWinForP2(checkColor);
        }

        private void OnP2BottomRight() {
            if (!_canInput) return;
            _canInput = false;
            var checkColor = uiManager.CheckButtonPressed(EnumBank.Players.P2, EnumBank.ButtonsPosition.BottomRight, p2Mask.CorrectColorName);
            CheckWinForP2(checkColor);
        }

        #endregion
    }
}

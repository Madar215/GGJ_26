using System.Collections.Generic;
using Mask;
using TMPro;
using UnityEngine;
using Utilities;

namespace Managers {
    public class UiManager : MonoBehaviour {
        [Header("Refs")]
        [SerializeField] private GameManager gameManager;
        [SerializeField] private RandomManager randomManager;

        [Header("P1")] 
        [SerializeField] private TextMeshProUGUI p1Score;
        [SerializeField] private List<ColorButton> p1ColorsButtons;
        
        [Header("P2")]
        [SerializeField] private TextMeshProUGUI p2Score;
        [SerializeField] private List<ColorButton> p2ColorsButtons;

        private int _p1ScoreNum;
        private int _p2ScoreNum;

        private void OnEnable() {
            gameManager.OnRoundStart += OnRoundStart;
            gameManager.OnRoundEnd += RaisePlayerScore;
        }

        private void OnDisable() {
            gameManager.OnRoundStart -= OnRoundStart;
            gameManager.OnRoundEnd -= RaisePlayerScore;
        }

        private void OnRoundStart() {
            // Get new colors
            randomManager.MakeRandomColors(p1ColorsButtons, EnumBank.Players.P1);
            randomManager.MakeRandomColors(p2ColorsButtons, EnumBank.Players.P2);
        }

        public bool CheckButtonPressed(EnumBank.Players player ,EnumBank.ButtonsPosition buttonPosition, string colorName) {
            switch (player) {
                case EnumBank.Players.P1:
                {
                    foreach (var colorButton in p1ColorsButtons) {
                        if (colorButton.IsSameColorOption(buttonPosition)) {
                            return colorButton.text.text == colorName;
                        }
                    }
                    return false;
                }
                case EnumBank.Players.P2:
                {
                    foreach (var colorButton in p2ColorsButtons) {
                        if (colorButton.IsSameColorOption(buttonPosition)) {
                            return colorButton.text.text == colorName;
                        }
                    }
                    return false;
                }
                default:
                    return false;
            }
        }

        private void RaisePlayerScore(int p1ScoreNum, int p2ScoreNum) {
            p1Score.text = p1ScoreNum.ToString();
            p2Score.text = p2ScoreNum.ToString();
        }
    }
}
using System.Collections.Generic;
using System.Globalization;
using Mask;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Managers {
    public class UiManager : MonoBehaviour {
        [Header("Refs")]
        [SerializeField] private GameManager gameManager;
        [SerializeField] private RandomManager randomManager;
        
        [Header("Screen")]
        [SerializeField] private GameObject gameplayScreen;
        [SerializeField] private GameObject gameOverScreen;

        [Header("P1")] 
        [SerializeField] private List<ColorButton> p1ColorsButtons;
        
        [Header("P2")]
        [SerializeField] private List<ColorButton> p2ColorsButtons;
        
        [Header("Timer")]
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private Image radialImage;
        
        [Header("Game Over")]
        [SerializeField] private TextMeshProUGUI gameOverText;
        
        private void OnEnable() {
            gameManager.OnRoundStart += OnRoundStart;
            gameManager.OnTimeChanged += OnTimeChanged;
            gameManager.OnSecondProgressChanged += OnSecondProgressChanged;
            gameManager.OnGameOver += OnGameOver;
        }

        private void OnDisable() {
            gameManager.OnRoundStart -= OnRoundStart;
            gameManager.OnTimeChanged -= OnTimeChanged;
            gameManager.OnSecondProgressChanged -= OnSecondProgressChanged;
            gameManager.OnGameOver -= OnGameOver;
        }

        private void OnRoundStart() {
            // Get new colors
            randomManager.MakeRandomColors(p1ColorsButtons, EnumBank.Players.P1);
            randomManager.MakeRandomColors(p2ColorsButtons, EnumBank.Players.P2);
        }

        private void OnTimeChanged(int time) {
            timerText.SetText(time.ToString(CultureInfo.InvariantCulture));
        }
        
        private void OnSecondProgressChanged(float p) {
            radialImage.fillAmount = p;
        }

        private void OnGameOver(EnumBank.Players player) {
            gameplayScreen.SetActive(false);
            gameOverScreen.SetActive(true);

            if (player == EnumBank.Players.P1) {
                gameOverText.SetText("Player 1 Wins!");
            }

            if (player == EnumBank.Players.P2) {
                gameOverText.SetText("Player 2 Wins!");
            }
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
    }
}
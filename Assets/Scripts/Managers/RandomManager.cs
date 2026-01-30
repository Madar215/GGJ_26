using System;
using System.Collections.Generic;
using Mask;
using UnityEngine;
using Utilities;
using Random = UnityEngine.Random;

namespace Managers {
    public class RandomManager : MonoBehaviour {
        [Header("Refs")]
        [SerializeField] private GameManager gameManager;
        [SerializeField] private Mask.Mask p1Mask;
        [SerializeField] private Mask.Mask p2Mask;
        
        [SerializeField] private ColorSettings colorSettings;
        private List<Color> _colorOptions;
        private List<string>  _colorNames;

        private void Awake() {
            _colorOptions = new List<Color>();
            foreach (var colorData in colorSettings.colorList) {
                _colorOptions.Add(colorData.color);
            }

            _colorNames = new List<string>();
            foreach (var colorData in colorSettings.colorList) {
                _colorNames.Add(colorData.displayName);
            }
        }

        private void OnRoundStart() {
            var p1Random = Random.Range(0, (int)EnumBank.ColorOptions.MaxColors);
            var p1CorrectColor = (EnumBank.ColorOptions)p1Random;
            
            var p2Random = Random.Range(0, (int)EnumBank.ColorOptions.MaxColors);
            var p2CorrectColor = (EnumBank.ColorOptions)p2Random;

            p1Mask.SetSpriteColor(p1CorrectColor);
            p2Mask.SetSpriteColor(p2CorrectColor);
        }

        private void MakeRandomMask(EnumBank.Players player) {
            if (player == EnumBank.Players.P1) {
                var p1Random = Random.Range(0, (int)EnumBank.ColorOptions.MaxColors);
                var p1CorrectColor = (EnumBank.ColorOptions)p1Random;
                p1Mask.SetSpriteColor(p1CorrectColor);
            }

            if (player == EnumBank.Players.P2) {
                var p2Random = Random.Range(0, (int)EnumBank.ColorOptions.MaxColors);
                var p2CorrectColor = (EnumBank.ColorOptions)p2Random;
                p2Mask.SetSpriteColor(p2CorrectColor);
            }
        }

        public void MakeRandomColors(List<ColorButton> colorButtons, EnumBank.Players player) {
            MakeRandomMask(player);
            
            var copiedColors = ShuffleAndReturn(_colorOptions);
            var copiedColorNames = ShuffleAndReturn(_colorNames);
            
            int correctColorRng = Random.Range(0, colorButtons.Count);
            int idx = 0;

            foreach (var colorButton in colorButtons) {
                
                colorButton.SetColor(copiedColors[idx]);
                if (idx == correctColorRng) {
                    if (player == EnumBank.Players.P1) {
                        colorButton.SetColorName(p1Mask.CorrectColorName);
                    }
                    if (player == EnumBank.Players.P2) {
                        colorButton.SetColorName(p2Mask.CorrectColorName);
                    }
                }
                else {
                    colorButton.SetColorName(copiedColorNames[idx]);
                }
                
                idx++;
            }
        }

        private static List<T> ShuffleAndReturn<T>(List<T> original)
        {
            var list = new List<T>(original);

            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }

            return list;
        }
    }
}
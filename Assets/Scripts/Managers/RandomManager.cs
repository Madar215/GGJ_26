using System.Collections.Generic;
using Animations;
using Mask;
using UnityEngine;
using UnityEngine.Events;
using Utilities;
using Random = UnityEngine.Random;

namespace Managers {
    public class RandomManager : MonoBehaviour {
        // Events
        public event UnityAction<MaskAnimation, EnumBank.Players> OnAnimationChange;
        
        [Header("Refs")]
        [SerializeField] private GameManager gameManager;
        [SerializeField] private Mask.Mask p1Mask;
        [SerializeField] private Mask.Mask p2Mask;
        
        [SerializeField] private ColorSettings colorSettings;
        [SerializeField] private List<MaskAnimation> circleMaskAnimations;
        [SerializeField] private List<MaskAnimation> demonMaskAnimations;
        [SerializeField] private List<MaskAnimation> eggMaskAnimations;
        [SerializeField] private List<Sprite> maskBodyTypes;
        
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

        private void OnEnable() {
            gameManager.OnMaskChange += MakeRandomAnimation;
        }

        private void OnDisable() {
            gameManager.OnMaskChange -= MakeRandomAnimation;
        }

        private void MakeRandomAnimation(EnumBank.Players player) {
            var bodyRng = Random.Range(0, (int)EnumBank.MaskType.MaxType);
            var animationRngTest = Random.Range(0,2);
            
            if (player == EnumBank.Players.P1) {
                p1Mask.SetBodySprite(maskBodyTypes[bodyRng]);
                switch ((EnumBank.MaskType)bodyRng) {
                    case EnumBank.MaskType.Circle:
                        OnAnimationChange?.Invoke(circleMaskAnimations[animationRngTest], EnumBank.Players.P1);
                        break;
                    case EnumBank.MaskType.Demon:
                        OnAnimationChange?.Invoke(demonMaskAnimations[animationRngTest], EnumBank.Players.P1);
                        break;
                    case EnumBank.MaskType.Egg:
                        OnAnimationChange?.Invoke(eggMaskAnimations[animationRngTest], EnumBank.Players.P1);
                        break;
                }
            }

            if (player == EnumBank.Players.P2) {
                p2Mask.SetBodySprite(maskBodyTypes[bodyRng]);
                switch ((EnumBank.MaskType)bodyRng) {
                    case EnumBank.MaskType.Circle:
                        OnAnimationChange?.Invoke(circleMaskAnimations[animationRngTest], EnumBank.Players.P2);
                        break;
                    case EnumBank.MaskType.Demon:
                        OnAnimationChange?.Invoke(demonMaskAnimations[animationRngTest], EnumBank.Players.P2);
                        break;
                    case EnumBank.MaskType.Egg:
                        OnAnimationChange?.Invoke(eggMaskAnimations[animationRngTest], EnumBank.Players.P2);
                        break;
                }
            }
        }

        private void MakeRandomMask(EnumBank.Players player) {
            var randomBody = Random.Range(0, (int)EnumBank.ColorOptions.MaxColors);
            var correctBodyColor = (EnumBank.ColorOptions)randomBody;
            
            var randomBorder = Random.Range(0, (int)EnumBank.ColorOptions.MaxColors);
            while (randomBorder == randomBody) {
                randomBorder = Random.Range(0, (int)EnumBank.ColorOptions.MaxColors);
            }
            var borderColor = (EnumBank.ColorOptions)randomBorder;
            
            if (player == EnumBank.Players.P1) {
                p1Mask.SetSpriteColor(correctBodyColor);
                p1Mask.SetFrameColor(borderColor);
            }
            if (player == EnumBank.Players.P2) {
                p2Mask.SetSpriteColor(correctBodyColor);
                p2Mask.SetFrameColor(borderColor);
            }
        }

        public void MakeRandomColors(List<ColorButton> colorButtons, EnumBank.Players player) {
            MakeRandomMask(player);
            
            var copiedButtons = new List<ColorButton>(colorButtons);
            var copiedColors = new List<Color>(_colorOptions);
            var copiedColorNames = new List<string>(_colorNames);
            
            int correctButtonRng = Random.Range(0, colorButtons.Count);
            int correctColorRng = Random.Range(0, (int)EnumBank.ColorOptions.MaxColors);

            if (player == EnumBank.Players.P1) {
                colorButtons[correctButtonRng].SetColorName(p1Mask.CorrectColorName);
                colorButtons[correctButtonRng].SetColor(copiedColors[correctColorRng]);
                
                copiedColorNames.Remove(p1Mask.CorrectColorName);
                copiedColors.RemoveAt(correctColorRng);
            }
            if (player == EnumBank.Players.P2) {
                colorButtons[correctButtonRng].SetColorName(p2Mask.CorrectColorName);
                colorButtons[correctButtonRng].SetColor(copiedColors[correctColorRng]);
                
                copiedColorNames.Remove(p2Mask.CorrectColorName);
                copiedColors.RemoveAt(correctColorRng);
            }
            copiedButtons.RemoveAt(correctButtonRng);

            foreach (var colorButton in copiedButtons) {
                int rngColor = Random.Range(0, copiedColors.Count);
                int rngName = Random.Range(0, copiedColorNames.Count);
                
                colorButton.SetColor(copiedColors[rngColor]);
                colorButton.SetColorName(copiedColorNames[rngName]);
                
                copiedColors.RemoveAt(rngColor); 
                copiedColorNames.RemoveAt(rngName);
            }
        }
    }
}
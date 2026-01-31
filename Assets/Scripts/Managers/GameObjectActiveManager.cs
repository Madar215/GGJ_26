using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Managers {
    public class GameObjectActiveManager : MonoBehaviour {
        [Header("Refs")]
        [SerializeField] private GameManager gameManager;
        
        [Header("Background Sprites")] 
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite gameplay;
        [SerializeField] private Sprite gameOver;

        [Header("Game Objects")] 
        [SerializeField] private List<GameObject> gameObjectsToTurnOff = new();
        [SerializeField] private List<GameObject> gameObjectsToTurnOn = new();

        private void OnEnable() {
            gameManager.OnGameOver += OnGameOver;
        }

        private void OnDisable() {
            gameManager.OnGameOver -= OnGameOver;
        }

        private void OnGameOver(EnumBank.Players player) {
            spriteRenderer.sprite = gameOver;
            
            foreach (var go in gameObjectsToTurnOff) {
                if(!go) continue;
                go.SetActive(false);
            }

            foreach (var go in gameObjectsToTurnOn) {
                if(!go) continue;
                go.SetActive(true);
            }
        }
    }
}
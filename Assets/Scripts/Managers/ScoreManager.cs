using UnityEngine;
using Managers;
using Score;

public class ScoreManager : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private GameManager gameManager;

    [Header("Bulb Strips")]
    [SerializeField] private ScoreBulbStrip p1Bulbs;
    [SerializeField] private ScoreBulbStrip p2Bulbs;

    private void OnEnable()
    {
        if (gameManager != null)
            gameManager.OnRoundEnd += HandleRoundEnd;
    }

    private void OnDisable()
    {
        if (gameManager != null)
            gameManager.OnRoundEnd -= HandleRoundEnd;
    }

    private void Start()
    {
        // Optional: start scene with all bulbs off
        if (p1Bulbs != null) p1Bulbs.ResetAll();
        if (p2Bulbs != null) p2Bulbs.ResetAll();
    }

    private void HandleRoundEnd(int p1Score, int p2Score)
    {
        if (p1Bulbs != null) p1Bulbs.SetScore(p1Score);
        if (p2Bulbs != null) p2Bulbs.SetScore(p2Score);
    }
}

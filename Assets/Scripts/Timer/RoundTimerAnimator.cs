using UnityEngine;
using Managers;

public class RoundTimerAnimator : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer timerSprite;


    [Header("Clip")]
    [Tooltip("Animation clip name inside the controller (exact name).")]
    [SerializeField] private string clipName = "Timer";

    [Header("Round")]
    [SerializeField] private float roundDuration = 5f; // must match GameManager roundTime

    private AnimationClip _clip;

    private void Awake()
    {
        if (animator == null) animator = GetComponent<Animator>();

        // Find the clip by name from the animator controller
        if (animator != null && animator.runtimeAnimatorController != null)
        {
            foreach (var c in animator.runtimeAnimatorController.animationClips)
            {
                if (c != null && c.name == clipName)
                {
                    _clip = c;
                    break;
                }
            }
        }
    }

    private void OnEnable()
    {
        if (gameManager == null) return;
        gameManager.OnRoundStart += HandleRoundStart;
        gameManager.OnRoundEnd += HandleRoundEnd;
    }

    private void OnDisable()
    {
        if (gameManager == null) return;
        gameManager.OnRoundStart -= HandleRoundStart;
        gameManager.OnRoundEnd -= HandleRoundEnd;
    }

    private void HandleRoundStart()
    {
        if (animator == null) return;

        if (timerSprite != null)
            timerSprite.enabled = true;   // SHOW

        animator.speed = 1f;
        animator.Play(clipName, 0, 0f);

        if (_clip != null && roundDuration > 0f)
            animator.speed = _clip.length / roundDuration;
    }

    private void HandleRoundEnd(int p1, int p2)
    {
        if (animator == null) return;

        animator.Play(clipName, 0, 1f);
        animator.speed = 0f;

        if (timerSprite != null)
            timerSprite.enabled = false;   // HIDE
    }
}

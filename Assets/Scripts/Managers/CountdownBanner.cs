using UnityEngine;
using TMPro;
using DG.Tweening;

namespace Managers {
    public class CountdownBanner : MonoBehaviour {
        [Header("Refs")]
        [SerializeField] private GameManager gameManager;
        [SerializeField] private RectTransform banner;
        [SerializeField] private TMP_Text text;

        [Header("Tween")]
        [SerializeField] private float popDuration = 0.22f;
        [SerializeField] private float shrinkDuration = 0.12f;
        [SerializeField] private float holdDuration = 0.35f;
        [SerializeField] private Ease popEase = Ease.OutBack;

        private Sequence _seq;

        private void Awake() {
            //gameObject.SetActive(false);
            banner.localScale = Vector3.zero;
        }

        private void OnEnable() {
            gameManager.StartOverTimer.OnTimerStop +=  OnTimerFinished;
            gameManager.StartOverTimer.OnTimerStart +=  OnTimerStarted;
            gameManager.OnStartOverTimerTick += OnTimerTick;
        }

        private void OnDisable() {
            gameManager.StartOverTimer.OnTimerStop -=  OnTimerFinished;
            gameManager.StartOverTimer.OnTimerStart -=  OnTimerStarted;
            gameManager.OnStartOverTimerTick -= OnTimerTick;
        }

        private void OnTimerTick(float remainingSeconds) {
            Debug.Log(remainingSeconds);
            if (remainingSeconds <= 0) return;
            ShowNumber(remainingSeconds);
        }

        private void OnTimerStarted() {
            gameObject.SetActive(true);
        }
        
        private void OnTimerFinished() {
            Hide();
        }

        private void ShowNumber(float number) {
            gameObject.SetActive(true);
            int roundedNumber = Mathf.CeilToInt(number);
            text.SetText(roundedNumber.ToString());

            _seq?.Kill();
            banner.localScale = Vector3.zero;

            _seq = DOTween.Sequence()
                .Append(banner.DOScale(1f, popDuration).SetEase(popEase))
                .AppendInterval(holdDuration)
                .Append(banner.DOScale(0f, shrinkDuration).SetEase(Ease.InBack));
        }

        private void Hide() {
            _seq?.Kill();
            banner.DOScale(0f, 0.1f).OnComplete(() => gameObject.SetActive(false));
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;

namespace PlanATest.core
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField]
        protected GameObject root;
        [SerializeField]
        protected Button buttonRetry;

        protected Action retryAction;

        private void Awake()
        {
            Hide();
        }

        public void RegisterRetryEvent(Action retry)
        {
            retryAction = retry;
            buttonRetry.onClick.AddListener(OnRetryTouched);
        }

        protected void OnRetryTouched()
        {
            Hide();
            retryAction?.Invoke();
        }

        public void RemoveRetryEvent()
        {
            retryAction = null;
            buttonRetry.onClick.RemoveAllListeners();
        }

        public void Hide()
        {
            root.SetActive(false);
        }

        public void Show()
        {
            root.SetActive(true);
        }
    }
}
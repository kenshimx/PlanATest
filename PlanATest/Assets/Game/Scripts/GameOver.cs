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

        private void Awake()
        {
            Hide();
        }

        public void RegisterRetryEvent(Action retry)
        {
            buttonRetry.onClick.AddListener(() => retry());
        }

        public void RemoveRetryEvent()
        {
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
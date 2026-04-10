using TMPro;
using UnityEngine;

namespace PlanATest.core
{
    public class GameScore : MonoBehaviour
    {
        [SerializeField]
        protected TMP_Text text;
        public int Score { get; protected set; }

        public void SetScore(int movesCount)
        {
            this.Score = movesCount;
            text.text = movesCount.ToString();
        }
    }
}
using TMPro;
using UnityEngine;

namespace PlanATest.core
{
    public class GameMoves : MonoBehaviour
    {
        [SerializeField]
        protected TMP_Text text;
        public int movesCount { get; protected set; }

        public void SetMovesCount(int movesCount)
        {
            this.movesCount = movesCount;
            text.text = movesCount.ToString();
        }
    }
}
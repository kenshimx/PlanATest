using System.Collections;
using UnityEngine;

namespace PlanATest.core
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        protected GridController gridController;
        [SerializeField]
        protected GameOver gameOverPopup;
        [SerializeField]
        protected GameScore gameScore;
        [SerializeField]
        protected GameMoves gameMoves;

        [SerializeField]
        protected MakeMove gameMakeMove;

        protected void Start()
        {
            //initialize grid
            if (gridController != null)
            {
                gridController.BuildGrid();
                gridController.OnPlayDone = PlayMade;
            }

            //for test in task 2
            if (gameMakeMove != null)
                gameMakeMove.RegisterEvent(FakePlay);

            if (gameOverPopup != null)
                gameOverPopup.RegisterRetryEvent(ReStartGame);

            ReStartGame();
        }

        protected void PlayMade(int score)
        {
            gameScore?.SetScore(gameScore.Score + score);
            gameMoves?.SetMovesCount(gameMoves.movesCount - 1);

            StartCoroutine(WaitNext());
        }

        IEnumerator WaitNext()
        {
            yield return new WaitForSeconds(1f);

            //on timer restore for next move or end the game if no more moves
            if (gameMoves.movesCount <= 0)
                gameOverPopup.Show();
            else
                gridController.RepositionGridCells();
        }

        protected void FakePlay()
        {
            gameScore?.SetScore(gameScore.Score + 10);
            gameMoves?.SetMovesCount(gameMoves.movesCount - 1);
            if (gameMoves.movesCount <= 0)
                gameOverPopup.Show();
        }
        

        private void ReStartGame()
        {
            gameScore.SetScore(0);
            gameMoves.SetMovesCount(5);
            gridController.ReStartGrid();
        }
    }
}
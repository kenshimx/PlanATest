using Unity.VisualScripting;
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

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        protected void Start()
        {

            if (gameOverPopup != null) 
                gameOverPopup.RegisterRetryEvent(ReStartGame);

            //initialize grid
            if (gridController != null)
                gridController.BuildGrid();

            if (gameMakeMove != null)
                gameMakeMove.RegisterEvent(FakePlay);

            if (gameOverPopup != null)
                gameOverPopup.RegisterRetryEvent(ReStartGame);

            ReStartGame();
        }

        protected void FakePlay()
        {
            gameScore?.SetScore(gameScore.Score + 10);
            gameMoves?.SetMovesCount(gameMoves.movesCount - 1);
            if (gameMoves.movesCount <= 0)
            {
                gameOverPopup.Show();
            }
        }
        

        private void ReStartGame()
        {
            gameScore.SetScore(0);
            gameMoves.SetMovesCount(5);
            gridController.ReStartGrid();
        }
    }
}
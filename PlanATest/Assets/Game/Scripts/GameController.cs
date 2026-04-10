using PlanATest.cell;
using System;
using UnityEngine;

namespace PlanATest.core
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        protected Cell cellPrefab;
        [SerializeField]
        protected GameOver gameOverPopup;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        protected void Start()
        {

            if (gameOverPopup == null) 
                gameOverPopup.RegisterRetryEvent(ReStartGame);
        }

        private void BuildGrid()
        {
            
        }

        private void ReStartGame()
        {
           
        }
    }
}
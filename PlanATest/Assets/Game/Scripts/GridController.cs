using System;
using System.Collections.Generic;
using UnityEngine;
namespace PlanATest.core
{
    public class GridController : MonoBehaviour
    {
        [SerializeField]
        protected Cell cellPrefab;
        [SerializeField]
        protected Transform cellParent;

        [Space(10), Header("Layout"), SerializeField]
        protected GridLayout gridLayout;


        protected Cell[,] gridData;

        public void BuildGrid()
        {
            //set grid size
            gridData = new Cell[gridLayout.gridSize.x, gridLayout.gridSize.y];

            int rows = gridData.GetLength(0);
            int cols = gridData.GetLength(1);
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    //intantiate and position the cell
                    var cell = Instantiate(cellPrefab, cellParent);
                    cell.SetCellId(new Vector2Int(i, j));
                    cell.transform.localPosition = new Vector3(
                        gridLayout.startPosition.x + j * gridLayout.cellSize.x,
                        gridLayout.startPosition.y - i * gridLayout.cellSize.y,
                        0
                    );
                    gridData[i, j] = cell;
                }
            }
        }

        public void ReStartGrid()
        {
            var rnd = new System.Random();
            var poolTypes = new List<CellType>() { CellType.Green, CellType.Purple, CellType.Brown, CellType.Yellow, CellType.Pink };
            foreach (var cell in gridData)
                cell.SetCellType(poolTypes[rnd.Next(poolTypes.Count)]);
        }
    }

    [Serializable]
    public class GridLayout
    {
        public Vector2Int gridSize;
        public Vector2Int cellSize;
        public Vector2Int startPosition;

    }
}
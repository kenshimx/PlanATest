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

        public Action<int> OnPlayDone;

        protected Cell[,] gridData;
        protected System.Random rnd;
        protected List<CellType> poolTypes;
        protected bool canPlay;

        public void BuildGrid()
        {
            rnd = new System.Random();
            poolTypes = new List<CellType>() { CellType.Green, CellType.Purple, CellType.Brown, CellType.Yellow, CellType.Pink };

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
                    cell.RegisterTouchEvent(OnCellTouched);
                    cell.transform.localPosition = new Vector3(
                        gridLayout.startPosition.x + j * gridLayout.cellSize.x,
                        gridLayout.startPosition.y - i * gridLayout.cellSize.y,
                        0
                    );
                    gridData[i, j] = cell;
                }
            }
        }

        private void OnCellTouched(Vector2Int id)
        {
            if (!canPlay)
                return;
            canPlay = false;

            //make the magic here
            var result = new List<Vector2Int>();
            var mainType = gridData[id.x, id.y].Type;


            CheckCell(id);
            OnPlayDone(result.Count*10);

            void CheckCell(Vector2Int cellId)
            {
                if (cellId.x < 0 || cellId.x >= gridData.GetLength(0) || cellId.y < 0 || cellId.y >= gridData.GetLength(1))
                    return;
                var cell = gridData[cellId.x, cellId.y];
                if (cell.Visited)
                    return;
                cell.Visited = true;
                if (cell.Type == CellType.Empty)
                    return;
                if (cell.Type != mainType)
                    return;
                result.Add(cell.Id);
                cell.SetCellType(CellType.Empty);
                
                CheckCell(new Vector2Int(cellId.x + 1, cellId.y));
                CheckCell(new Vector2Int(cellId.x - 1, cellId.y));
                CheckCell(new Vector2Int(cellId.x, cellId.y + 1));
                CheckCell(new Vector2Int(cellId.x, cellId.y - 1));
            }
        }

        public void ReStartGrid()
        {
            foreach (var cell in gridData)
            {
                cell.SetCellType(poolTypes[rnd.Next(poolTypes.Count)]);
                cell.Visited = false;
            }
            canPlay = true;
        }

        public void RepositionGridCells()
        {
            int rows = gridData.GetLength(0);
            int cols = gridData.GetLength(1);
            for (var c = 0; c < cols; c++)
            {

                for (var r = 0; r < rows; r++)
                {
                    var cell = gridData[r, c];
                    if (cell.Type == CellType.Empty)
                    {
                        var found = false;
                        for (var r2 = r + 1; r2 < rows; r2++)
                        {
                            var cellOnTop = gridData[r2, c];
                            if (cellOnTop.Type != CellType.Empty)
                            {
                                cell.SetCellType(cellOnTop.Type);
                                cellOnTop.SetCellType(CellType.Empty);
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                            cell.SetCellType(poolTypes[rnd.Next(poolTypes.Count)]);
                    }
                }
            }

            foreach (var cell in gridData)
                cell.Visited = false;

            canPlay = true;
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
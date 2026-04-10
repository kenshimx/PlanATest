using UnityEngine;
namespace PlanATest.core
{
    public class GridController : MonoBehaviour
    {
        [SerializeField]
        protected Cell cellPrefab;

        protected int[,] gridData;
        public void BuildGrid()
        {
            gridData = new int[5, 5];
        }
    }
}
using PlanATest.utils;
using System;
using UnityEngine;

namespace PlanATest.core
{
    public class Cell : MonoBehaviour
    {
        public CellType Type { get; protected set; }
        public Vector2Int Id { get; protected set; }
        [SerializeField] 
        private SimpleImageTouch button;

        protected Action<Vector2Int> onTouched;

        public void SetCellId(Vector2Int id)
        {
            this.Id = id;
        }

        public void SetCellType(CellType type)
        {
            this.Type = type;
        }

        public void RegisterTouchEvent(Action<Vector2Int> touched)
        {
            button.OnClick = OnCellTouched;
        }

        protected void OnCellTouched(SimpleImageTouch touch)
        {
            onTouched?.Invoke(Id);
        }

        public void RemoveTouchEvent()
        {
            button.OnClick = null;
        }
    }

    public enum CellType
    {
        Empty,
        Red,
        Green,
        Blue,
        Yellow
    }
}
using PlanATest.utils;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlanATest.core
{
    public class Cell : MonoBehaviour
    {
        public CellType Type { get; protected set; }
        public Vector2Int Id { get; protected set; }
        [SerializeField] 
        protected SimpleImageTouch button;
        [SerializeField]
        protected List<CellSpriteData> cellSprites;

        protected Action<Vector2Int> onTouched;

        public void SetCellId(Vector2Int id)
        {
            this.Id = id;
        }

        public void SetCellType(CellType type)
        {
            this.Type = type;
            button.Image.sprite = cellSprites.Find(x => x.Type == type).CeelSprite;
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

    [Serializable]
    public struct CellSpriteData
    {
        public CellType Type;
        public Sprite CeelSprite;
    }

    [Serializable]
    public enum CellType
    {
        Empty,
        Green,
        Purple,
        Yellow,
        Brown,
        Pink
    }
}
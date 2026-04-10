using System;
using UnityEngine;
using UnityEngine.UI;

public class MakeMove : MonoBehaviour
{
    [SerializeField]
    protected Button buttonRetry;

    public void RegisterEvent(Action makeMove)
    {
        buttonRetry.onClick.AddListener(() => makeMove());
    }

    public void RemoveEvent()
    {
        buttonRetry.onClick.RemoveAllListeners();
    }
}

using System;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public event Action CreateCopy;
    public event Action DestroyOriginal;
    public event Action ExplodeOriginal;

    void OnMouseDown()
    {
        CreateCopy?.Invoke();
        ExplodeOriginal?.Invoke();
        DestroyOriginal?.Invoke();
    }
}
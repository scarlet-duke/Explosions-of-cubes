using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private ClickHandler _clickHandler;

    private void OnEnable()
    {
        _clickHandler.DestroyOriginal += DestroyObject;
    }

    private void OnDisable()
    {
        _clickHandler.DestroyOriginal -= DestroyObject;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}

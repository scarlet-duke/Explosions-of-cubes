using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    public event Action<Cube> CreateCopy;

    [SerializeField] private int _probabilityOfReplication = 100;
    [SerializeField] private Vector3 _scaleReduction = new Vector3(0.5f, 0.5f, 0.5f);

    public int MaximumProbability = 100;
    public int MinCountClone = 2;
    public int MaxCountClone = 6;

    public int ProbabilityOfReplication
    {
        get => _probabilityOfReplication;
        set => _probabilityOfReplication = Mathf.Clamp(value, 0, MaximumProbability);
    }

    public Vector3 ScaleReduction => _scaleReduction;

    private void OnMouseDown()
    {
        CreateCopy?.Invoke(this);
        Destroy(gameObject);
    }

    private void Awake()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
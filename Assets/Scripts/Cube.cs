using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _probabilityOfReplication = 100;
    [SerializeField] private Vector3 _scaleReduction = new Vector3(0.5f, 0.5f, 0.5f);
    [SerializeField] private int _maximumProbability = 100;
    [SerializeField] private int _minCountClone = 2;
    [SerializeField] private int _maxCountClone = 6;

    public int ProbabilityOfReplication
    {
        get => _probabilityOfReplication;
        set => _probabilityOfReplication = Mathf.Clamp(value, 0, _maximumProbability);
    }

    public Vector3 ScaleReduction => _scaleReduction;
    public int MaxCountClone => _maxCountClone;
    public int MinCountClone => _minCountClone;
    public int MaximumProbability => _maximumProbability;

    private void Awake()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
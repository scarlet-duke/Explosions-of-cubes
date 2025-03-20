using System;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action<Cube> CreateCopy;
    public event Action<Cube> ExplodeOriginal;

    [SerializeField] private int _probabilityOfReplication = 100;
    [SerializeField] private Vector3 _scaleReduction = new Vector3(0.5f, 0.5f, 0.5f);
    [SerializeField] private float _explosionRadius = 3f;
    [SerializeField] private float _explosionForce = 100f;

    public const int MaximumProbability = 100;
    public const int MinCountClone = 2;
    public const int MaxCountClone = 6;

    public List<Cube> Clones { get; private set; } = new List<Cube>();

    public int ProbabilityOfReplication
    {
        get => _probabilityOfReplication;
        set => _probabilityOfReplication = Mathf.Clamp(value, 0, MaximumProbability);
    }

    public Vector3 ScaleReduction => _scaleReduction;
    public float ExplosionRadius => _explosionRadius;
    public float ExplosionForce => _explosionForce;

    private void OnMouseDown()
    {
        CreateCopy?.Invoke(this);
        ExplodeOriginal?.Invoke(this);
        Destroy(gameObject);
    }
}
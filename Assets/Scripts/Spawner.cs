using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Explosion _explosion;
    public event Action<Cube> ExplodeOriginal;

    private void OnEnable()
    {
        _cube.CreateCopy += OnCreateCopy;
    }

    private void OnDisable()
    {
        _cube.CreateCopy -= OnCreateCopy;
    }

    private void OnCreateCopy(Cube cube)
    {
        Replicate(cube);
    }

    private void Replicate(Cube cube)
    {
        int cloneProbability = Random.Range(0, cube.MaximumProbability + 1);
        int cloneCount = Random.Range(cube.MinCountClone, cube.MaxCountClone + 1);
        List<Cube> Clones = new List<Cube>();

        if (cloneProbability <= cube.ProbabilityOfReplication)
        {
            for (int i = 0; i < cloneCount; i++)
            {
                Cube copyCube = Instantiate(cube);
                copyCube.ProbabilityOfReplication /= 2;
                copyCube.transform.localScale = cube.transform.localScale - cube.ScaleReduction;
                Clones.Add(copyCube);
            }
            _explosion.OnExplodeOriginal(Clones);
        }
    }
}
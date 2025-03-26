using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private float _explosionRadius = 3f;
    [SerializeField] private float _explosionForce = 100f;

    public List<Cube> Replicate(Cube cube)
    {
        int decreaseProbability = 2;
        int cloneProbability = Random.Range(0, cube.MaximumProbability + 1);
        int cloneCount = Random.Range(cube.MinCountClone, cube.MaxCountClone + 1);
        List<Cube> clones = new List<Cube>();

        if (cloneProbability <= cube.ProbabilityOfReplication)
        {
            for (int i = 0; i < cloneCount; i++)
            {
                Cube copyCube = Instantiate(cube);
                copyCube.ProbabilityOfReplication /= decreaseProbability;
                copyCube.transform.localScale = cube.transform.localScale - cube.ScaleReduction;
                clones.Add(copyCube);
            }
        }

        return clones;
    }
}
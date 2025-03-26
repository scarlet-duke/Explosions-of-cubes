using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosioner _explosion;

    public void OnCubeClick(Cube cube)
    {
        List<Rigidbody> rigidbodies = new List<Rigidbody>();

        foreach (Cube tempCube in _spawner.Replicate(cube))
        {
            if (tempCube.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbodies.Add(rigidbody);
            }
        }

        if (rigidbodies.Count > 0)
        {
            _explosion.Explode(rigidbodies);
        }
        else
        {
            _explosion.Explode(cube);
        }

        Destroy(cube.gameObject);
    }
}

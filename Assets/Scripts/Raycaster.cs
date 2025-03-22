using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosioner _explosion;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.TryGetComponent(out Cube cube))
                {
                    List<Rigidbody> rigidbodies = new List<Rigidbody>();

                    foreach (Cube tempCube in _spawner.Replicate(cube))
                    {
                        if(tempCube.TryGetComponent(out Rigidbody rigidbody))
                        {
                            rigidbodies.Add(rigidbody);
                        }
                    }

                    _explosion.Explode(rigidbodies);
                    Destroy(cube.gameObject);
                }
            }
        }
    }
}
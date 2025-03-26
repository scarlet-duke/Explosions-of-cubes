using System.Collections.Generic;
using UnityEngine;

public class Explosioner : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 15f;
    [SerializeField] private float _explosionForce = 500f;

    public void Explode(List<Rigidbody> rigidbodies)
    {
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            if (rigidbody != null)
            {
                Vector3 explosionDirection = (rigidbody.transform.position - transform.position).normalized;
                rigidbody.AddForce(explosionDirection * _explosionForce, ForceMode.Impulse);
            }
        }
    }

    public void Explode(Cube cube)
    {
        Collider[] colliders = Physics.OverlapSphere(cube.transform.position, _explosionRadius);

        foreach (Collider hit in colliders)
        {
            if (hit.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
            }
        }
    }
}

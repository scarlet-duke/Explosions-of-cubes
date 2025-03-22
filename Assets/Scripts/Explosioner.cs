using System.Collections.Generic;
using UnityEngine;

public class Explosioner : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 3f;
    [SerializeField] private float _explosionForce = 100f;

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
}

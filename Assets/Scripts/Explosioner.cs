using System.Collections.Generic;
using UnityEngine;

public class Explosioner : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 3f;
    [SerializeField] private float _explosionForce = 100f;
    int explosionModifier = 5;

    public void Explode(List<Rigidbody> rigidbodies)
    {
        if(rigidbodies.Count > 1)
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
        else
        {
            Collider[] colliders = Physics.OverlapSphere(rigidbodies[0].transform.position, _explosionRadius * explosionModifier);

            foreach (Collider hit in colliders)
            {
                Rigidbody rigidbody = hit.GetComponent<Rigidbody>();

                if (rigidbody != null)
                {
                    rigidbody.AddExplosionForce(_explosionForce * explosionModifier, rigidbodies[0].transform.position, _explosionRadius * explosionModifier);
                }
            }
        }

    }
}

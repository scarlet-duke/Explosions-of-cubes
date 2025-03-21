using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 3f;
    [SerializeField] private float _explosionForce = 100f;

    public void OnExplodeOriginal(List<Cube> Clones)
    {
        foreach (Cube cloneCube in Clones)
        {
            if (cloneCube != null)
            {
                Rigidbody rigidBody = cloneCube.GetComponent<Rigidbody>();
                if (rigidBody != null)
                {
                    Vector3 explosionDirection = (cloneCube.transform.position - transform.position).normalized;
                    rigidBody.AddForce(explosionDirection * _explosionForce, ForceMode.Impulse);
                }
            }
        }
    }
}
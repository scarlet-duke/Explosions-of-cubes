using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private ClickHandler _clickHandler;
    private float _explosionRadius = 3;
    private float _explosionForse = 100;

    private void OnEnable()
    {
        _clickHandler.ExplodeOriginal += Explode;
    }

    private void OnDisable()
    {
        _clickHandler.ExplodeOriginal -= Explode;
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(_explosionForse, transform.position, _explosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> explosion = new();

        foreach(Collider hit in hits)
            if (hit.attachedRigidbody != null)
                explosion.Add(hit.attachedRigidbody);

        return explosion;
    }
}

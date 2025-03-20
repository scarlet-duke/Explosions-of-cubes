using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private void OnEnable()
    {
        _cube.ExplodeOriginal += OnExplodeOriginal;
    }

    private void OnDisable()
    {
        _cube.ExplodeOriginal -= OnExplodeOriginal;
    }

    private void OnExplodeOriginal(Cube cube)
    {
        Explode(cube);
    }

    private void Explode(Cube cube)
    {
        foreach (Cube cloneCube in cube.Clones)
        {
            if (cloneCube != null)
            {
                Rigidbody rb = cloneCube.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 explosionDirection = (cloneCube.transform.position - cube.transform.position).normalized;
                    rb.AddForce(explosionDirection * cube.ExplosionForce, ForceMode.Impulse);
                }
            }
        }
    }
}
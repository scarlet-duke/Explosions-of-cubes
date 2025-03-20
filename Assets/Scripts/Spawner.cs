using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;

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
        int cloneProbability = UnityEngine.Random.Range(0, Cube.MaximumProbability + 1);
        int cloneCount = UnityEngine.Random.Range(Cube.MinCountClone, Cube.MaxCountClone + 1);

        if (cloneProbability <= cube.ProbabilityOfReplication)
        {
            for (int i = 0; i < cloneCount; i++)
            {
                GameObject copy = Instantiate(cube.gameObject);
                Cube copyCube = copy.GetComponent<Cube>();

                if (copyCube != null)
                {
                    copyCube.ProbabilityOfReplication /= 2;
                    copyCube.transform.localScale = cube.transform.localScale - cube.ScaleReduction;
                    copyCube.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();

                    cube.Clones.Add(copyCube);
                }
            }
        }
    }
}
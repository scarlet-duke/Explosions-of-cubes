using UnityEngine;

public class Randomizer : MonoBehaviour
{
    [SerializeField] private Replicater _replicater;

    private void OnEnable()
    {
        _replicater.Random += GenerateRandomNumber;
    }

    private void OnDisable()
    {
        _replicater.Random -= GenerateRandomNumber;
    }
    public int GenerateRandomNumber(int min, int max)
    {
        return Random.Range(min, max + 1);
    }
}

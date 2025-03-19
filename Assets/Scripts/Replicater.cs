using System;
using UnityEngine;

public class Replicater : MonoBehaviour
{
    [SerializeField] private ClickHandler _clickHandler;
    [SerializeField] private int _probabilityOfReplication = 100;
    public event Func<int, int, int> Random;
    private int _maximumProbability = 100;
    private int _minCountClone = 2;
    private int _maxCountClone = 6;

    private void OnEnable()
    {
        _clickHandler.CreateCopy += GeneratorObject;
    }

    private void OnDisable()
    {
        _clickHandler.CreateCopy -= GeneratorObject;
    }

    private void GeneratorObject()
    {
        int cloneProbability = Random?.Invoke(0, _maximumProbability) ?? _maximumProbability;
        int cloneCount = Random?.Invoke(_minCountClone, _maxCountClone) ?? _minCountClone;

        if (cloneProbability <= _probabilityOfReplication)
        {
            int newProbability = _probabilityOfReplication / 2;

            for (int i = 0; i < cloneCount; i++)
            {
                GameObject copy = Instantiate(gameObject);

                Replicater copyReplicater = copy.GetComponent<Replicater>();
                if (copyReplicater != null)
                {
                    copyReplicater._probabilityOfReplication = newProbability;
                }

                Renderer copyRenderer = copy.GetComponent<Renderer>();

                if (copyRenderer != null)
                {
                    copyRenderer.material.color = UnityEngine.Random.ColorHSV();
                }

                copy.transform.localScale = transform.localScale - new Vector3(0.5f, 0.5f, 0.5f);
            }
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _minCountSpawn = 2;
    [SerializeField] private int _maxCountSpawn = 6;
    [SerializeField] private int _decreasingObjectSize = 2;

    public List<GameObject> SpawnCubes(Cube originalCube, int divideChance, int decreasingProbability)
    {
        List<GameObject> newObjects = new List<GameObject>();

        int randomValue = Random.Range(_minCountSpawn, _maxCountSpawn + 1);

        for (int i = 0; i < randomValue; i++)
        {
            Cube newCube = Instantiate(originalCube, originalCube.transform.position, originalCube.transform.rotation);
            newCube.transform.localScale = originalCube.transform.localScale / _decreasingObjectSize;
            newCube.SetDivideChance(Mathf.Max(1, divideChance / decreasingProbability));
            
            newObjects.Add(newCube.gameObject);
        }

        return newObjects;
    }
}
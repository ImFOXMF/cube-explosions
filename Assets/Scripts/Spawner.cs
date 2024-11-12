using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _minCountSpawn = 2;
    [SerializeField] private int _maxCountSpawn = 6;
    [SerializeField] private int _decreasingObjectSize = 2;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private List<Cube> _initialCubes;

    private void Start()
    {
        if (_initialCubes != null)
            foreach (var cube in _initialCubes)
            {
                SubscribeToCube(cube);   
            }
    }

    private void SubscribeToCube(Cube cube)
    {
        cube.OnClicked += HandleCubeClicked;
    }

    private void HandleCubeClicked(Cube clickedCube)
    {
        var newCubes = SpawnCubes(clickedCube);
        _exploder.Explode(newCubes, clickedCube.transform.position);
    }

    private List<GameObject> SpawnCubes(Cube originalCube)
    {
        List<GameObject> newObjects = new List<GameObject>();

        int randomValue = Random.Range(_minCountSpawn, _maxCountSpawn + 1);

        for (int i = 0; i < randomValue; i++)
        {
            Cube newCube = Instantiate(originalCube, originalCube.transform.position, originalCube.transform.rotation);
            newCube.transform.localScale = originalCube.transform.localScale / _decreasingObjectSize;
            newCube.SetDivideChance(Mathf.Max(1, originalCube.GetDivideChance() / originalCube.GetDecreasingProbability()));

            SubscribeToCube(newCube);
            newObjects.Add(newCube.gameObject);
        }

        return newObjects;
    }
}
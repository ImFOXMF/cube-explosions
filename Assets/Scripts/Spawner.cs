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
        cube.ClickedAndDevided += OnCubeClickedAndDevided;
        cube.ClickedAndNotDevided += OnCubeClickedAndNotDevided;
    }

    private void OnCubeClickedAndDevided(Cube clickedCube)
    {
        clickedCube.ChangeDevidedStatus(true);
        List<Rigidbody> newCubes = SpawnCubes(clickedCube);

        _exploder.Activate(clickedCube, newCubes);

        clickedCube.ClickedAndDevided -= OnCubeClickedAndDevided;
    }

    private void OnCubeClickedAndNotDevided(Cube clickedCube)
    {
        clickedCube.ChangeDevidedStatus(false);

        _exploder.Activate(clickedCube);

        clickedCube.ClickedAndNotDevided -= OnCubeClickedAndNotDevided;
    }

    private List<Rigidbody> SpawnCubes(Cube originalCube)
    {
        List<Rigidbody> newRigidbodies = new List<Rigidbody>();

        int randomValue = Random.Range(_minCountSpawn, _maxCountSpawn + 1);

        for (int i = 0; i < randomValue; i++)
        {
            Cube newCube = Instantiate(originalCube, originalCube.transform.position, originalCube.transform.rotation);
            newCube.transform.localScale = originalCube.transform.localScale / _decreasingObjectSize;
            newCube.SetDivideChance(Mathf.Max(1, originalCube.DivideChance / originalCube.DecreasingProbability));

            SubscribeToCube(newCube);
            newRigidbodies.Add(newCube.GetComponent<Rigidbody>());
        }

        return newRigidbodies;
    }
}
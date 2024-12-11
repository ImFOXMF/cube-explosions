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
       List<Rigidbody> newCubes = SpawnCubes(clickedCube);
       
        _exploder.Explode(newCubes, clickedCube.transform.position);

        clickedCube.ClickedAndDevided -= OnCubeClickedAndDevided;
    }

    private void OnCubeClickedAndNotDevided(Cube clickedCube)
    {
        float koeffFromSize = clickedCube.BaseSize/clickedCube.transform.localScale.x;
        
        List<Rigidbody> affectedCubes = GetExplodableObjects(clickedCube);
        _exploder.ExplodeNotDevided(affectedCubes, clickedCube.transform.position, koeffFromSize);

        clickedCube.ClickedAndNotDevided -= OnCubeClickedAndNotDevided;
    }
    
    private List<Rigidbody> GetExplodableObjects(Cube clickedCube)
        {
            Collider[] hits = Physics.OverlapSphere(clickedCube.transform.position, _exploder.ExplosionRadius);
    
            List<Rigidbody> cubes = new();
    
            foreach (Collider hit in hits)
                if (hit.attachedRigidbody != null)
                    cubes.Add(hit.attachedRigidbody);
            
            return cubes;
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
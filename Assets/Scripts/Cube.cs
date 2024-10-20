using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private int _divideChance = 100;

    private int _minCountSpawn = 2;
    private int _maxCountSpawn = 6;

    private void OnMouseUpAsButton()
    {
        CubeExplosion explodeScript = gameObject.GetComponent<CubeExplosion>();

        List<GameObject> newObjects = new List<GameObject>();

        if (Random.Range(0, 100) < _divideChance)
            newObjects = Division();

        explodeScript.Explode(newObjects);
    }

    private List<GameObject> Division()
    {
        List<GameObject> newObjects = new List<GameObject>();

        _cubePrefab.transform.localScale = gameObject.transform.localScale / 2;

        int randomValue = Random.Range(_minCountSpawn, _maxCountSpawn);

        for (int i = 0; i < randomValue; i++)
        {
            GameObject newObject = Instantiate(_cubePrefab, gameObject.transform.position, gameObject.transform.rotation);
            Cube cubeScript = newObject.GetComponent<Cube>();

            if (cubeScript != null)
            {
                cubeScript._divideChance = Mathf.Max(1, _divideChance / 2);
            }

            SetRandomColor(newObject);
            newObjects.Add(newObject);
        }

        return newObjects;
    }

    private void SetRandomColor(GameObject newObject)
    {
        Renderer renderer = newObject.GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material.color = Random.ColorHSV();
        }
    }
}

using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _divideChance = 100;
    [SerializeField] private int _decreasingProbability = 2;

    private Spawner _spawner;
    private Exploder _exploder;

    private void Start()
    {
        _spawner = FindObjectOfType<Spawner>();
        _exploder = FindObjectOfType<Exploder>();

        SetRandomColor();
    }

    private void OnMouseUpAsButton()
    {
        if (Random.Range(0, 100) < _divideChance)
        {
            var newObjects = _spawner.SpawnCubes(this, _divideChance, _decreasingProbability);
            _exploder.Explode(newObjects, transform.position);
        }

        Destroy(gameObject);
    }

    private void SetRandomColor()
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material.color = Random.ColorHSV();
        }
    }

    public void SetDivideChance(int newChance)
    {
        _divideChance = newChance;
    }
}
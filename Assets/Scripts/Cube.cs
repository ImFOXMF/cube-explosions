using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _divideChance = 100;
    [SerializeField] private int _decreasingProbability = 2;

    private Spawner _spawner;
    private ExplosionManager _explosionManager;

    private void Start()
    {
        _spawner = FindObjectOfType<Spawner>();
        _explosionManager = FindObjectOfType<ExplosionManager>();
    }

    private void OnMouseUpAsButton()
    {
        if (Random.Range(0, 100) < _divideChance)
        {
            var newObjects = _spawner.SpawnCubes(this, _divideChance, _decreasingProbability);
            _explosionManager.Explode(newObjects, transform.position);
        }

        Destroy(gameObject);
    }

    public void SetDivideChance(int newChance)
    {
        _divideChance = newChance;
    }
}

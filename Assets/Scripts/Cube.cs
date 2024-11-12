using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _divideChance = 100;
    [SerializeField] private int _decreasingProbability = 2;

    public event Action<Cube> OnClicked;

    private void Start()
    {
        SetRandomColor();
    }

    private void OnMouseUpAsButton()
    {
        if (Random.Range(0, 100) < _divideChance)
        {
            OnClicked?.Invoke(this);
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
    
    public int GetDivideChance() => _divideChance;
    
    public int GetDecreasingProbability() => _decreasingProbability;
}
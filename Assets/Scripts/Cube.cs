using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    private Renderer _renderer;

    public event Action<Cube> Clicked;

    [field: SerializeField] public int DivideChance {get; private set;} = 100;
    [field: SerializeField] public int DecreasingProbability {get; private set;} = 2;
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        SetRandomColor();
    }

    private void OnMouseUpAsButton()
    {
        if (Random.Range(0, 100) < DivideChance)
        {
            Clicked?.Invoke(this);
        }

        Destroy(gameObject);
    }

    private void SetRandomColor()
    {
        _renderer.material.color = Random.ColorHSV();
    }

    public void SetDivideChance(int newChance)
    {
        DivideChance = newChance;
    }
}
using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(ColorChanger))]
public class Cube : MonoBehaviour
{
    private int _minRandom = 0;
    private int _maxRandom = 100;

    public event Action<Cube> ClickedAndDevided;
    public event Action<Cube> ClickedAndNotDevided;

    [field: SerializeField] public int DivideChance { get; private set; } = 100;
    [field: SerializeField] public int DecreasingProbability { get; private set; } = 2;
    [field: SerializeField] public int BaseSize { get; private set; } = 1;
    [field: SerializeField] public bool IsDevided { get; private set; }

    private void OnMouseUpAsButton()
    {
        if (Random.Range(_minRandom, _maxRandom) < DivideChance)
            ClickedAndDevided?.Invoke(this);
        else
            ClickedAndNotDevided?.Invoke(this);

        Destroy(gameObject);
    }

    public void SetDivideChance(int newChance) => DivideChance = newChance;

    public void ChangeDevidedStatus(bool isDevided) => IsDevided = isDevided;
}
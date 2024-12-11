using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        SetRandomColor();
    }

    private void SetRandomColor() => _renderer.material.color = Random.ColorHSV();
}
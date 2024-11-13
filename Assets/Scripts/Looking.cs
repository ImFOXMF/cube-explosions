using UnityEngine;

public class Looking : MonoBehaviour
{
    private readonly string _mouseX = "Mouse X";
    private readonly string _mouseY = "Mouse Y";

    [SerializeField] private float _speed;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _body;

    private void Update()
    {
        _camera.Rotate(_speed * -Input.GetAxis(_mouseY) * Time.deltaTime * Vector3.right);
        _body.Rotate(_speed * Input.GetAxis(_mouseX) * Time.deltaTime * Vector3.up);
    }
}

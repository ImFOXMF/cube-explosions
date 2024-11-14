using UnityEngine;

public class Movement : MonoBehaviour
{
    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";

    [SerializeField] private float _speed;

    private void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis(_horizontal), 0f, Input.GetAxis(_vertical));

        transform.Translate(_speed * Time.deltaTime * direction);
    }
}

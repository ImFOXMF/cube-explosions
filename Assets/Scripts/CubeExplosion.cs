using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(List<GameObject> affectedObjects)
    {
        foreach (GameObject affectedObject in affectedObjects)
        {
            Rigidbody rb = affectedObject.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        Destroy(gameObject);
    }
}

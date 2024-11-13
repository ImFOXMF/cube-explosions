using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _explosionForce = 700f;

    public void Explode(List<Cube> affectedObjects, Vector3 explosionCenter)
    {
        foreach (Cube affectedObject in affectedObjects)
        {
            Rigidbody objectRigidbody = affectedObject.GetComponent<Rigidbody>();

            if (objectRigidbody != null)
            {
                objectRigidbody.AddExplosionForce(_explosionForce, explosionCenter, _explosionRadius);
            }
        }
    }
}

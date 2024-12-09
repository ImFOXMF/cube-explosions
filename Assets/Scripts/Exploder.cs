using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [field: SerializeField] public float ExplosionRadius = 100f;
    [SerializeField] private float _explosionForce = 700f;

    public void Explode(List<Cube> affectedObjects, Vector3 explosionCenter)
    {
        foreach (Cube affectedObject in affectedObjects)
        {
            Rigidbody objectRigidbody = affectedObject.GetComponent<Rigidbody>();

            if (objectRigidbody != null)
            {
                objectRigidbody.AddExplosionForce(_explosionForce, explosionCenter, ExplosionRadius);
            }
        }
    }

    public void ExplodeNotDevided(List<Rigidbody> affectedObjects, Vector3 explosionCenter, float koeffFromSize)
    {
        foreach (Rigidbody explodableObject in affectedObjects)
        {
            float distance = Vector3.Distance(explodableObject.transform.position, transform.position);
            float koeffFromDistance = distance / ExplosionRadius;

            float finalExplosionForce = _explosionForce * koeffFromDistance;
            float finalExplosionRadius = ExplosionRadius * koeffFromSize;

            explodableObject.AddExplosionForce(finalExplosionForce, explosionCenter, finalExplosionRadius);
        }
    }
}
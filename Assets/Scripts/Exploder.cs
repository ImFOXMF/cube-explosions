using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [field: SerializeField] public float ExplosionRadius = 15f;
    [SerializeField] private float _explosionForce = 700f;

    public void Explode(List<Rigidbody> affectedObjects, Vector3 explosionCenter)
    {
        foreach (Rigidbody affectedObject in affectedObjects)
        {
            if (affectedObject != null)
            {
                affectedObject.AddExplosionForce(_explosionForce, explosionCenter, ExplosionRadius);
            }
        }
    }

    public void ExplodeNotDevided(List<Rigidbody> affectedObjects, Vector3 explosionCenter, float koeffFromSize)
    {
        foreach (Rigidbody affectedOject in affectedObjects)
        {
            float distance = Vector3.Distance(affectedOject.transform.position, transform.position);
            float koeffFromDistance = ExplosionRadius / distance;

            float finalExplosionForce = _explosionForce * koeffFromDistance;
            float finalExplosionRadius = ExplosionRadius * koeffFromSize;
            
            affectedOject.AddExplosionForce(finalExplosionForce, explosionCenter,
                finalExplosionRadius);
        }
    }
}
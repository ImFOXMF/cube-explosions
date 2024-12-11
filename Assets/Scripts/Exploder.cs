using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 15f;
    [SerializeField] private float _explosionForce = 700f;

    public void Activate(Cube clickedCube, List<Rigidbody> affectedObjects = null)
    {
        if (clickedCube.IsDevided)
            Explode(clickedCube, affectedObjects);
        else
            ExplodeNotDevided(clickedCube);
    }

    private void Explode(Cube clickedCube, List<Rigidbody> affectedObjects)
    {
        foreach (Rigidbody affectedObject in affectedObjects)
        {
            affectedObject.AddExplosionForce(_explosionForce, clickedCube.transform.position, _explosionRadius);
        }
    }

    private void ExplodeNotDevided(Cube clickedCube)
    {
        float koeffFromSize = clickedCube.BaseSize / clickedCube.transform.localScale.x;
        float finalExplosionRadius = _explosionRadius * koeffFromSize;

        List<Rigidbody> affectedObjects = GetExplodableObjects(clickedCube);

        foreach (Rigidbody affectedOject in affectedObjects)
        {
            float distance = Vector3.Distance(affectedOject.transform.position, transform.position);
            float koeffFromDistance = _explosionRadius / distance;

            float finalExplosionForce = _explosionForce * koeffFromDistance;

            affectedOject.AddExplosionForce(finalExplosionForce, clickedCube.transform.position,
                finalExplosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects(Cube clickedCube)
    {
        Collider[] hits = Physics.OverlapSphere(clickedCube.transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}
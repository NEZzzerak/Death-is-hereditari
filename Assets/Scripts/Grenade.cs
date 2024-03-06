using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3;
    public GameObject explosionPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Exsplosion", delay);
    }
    private void Exsplosion ()
    {
        Destroy(gameObject);
        var instantiate=Instantiate(explosionPrefab);
        instantiate.transform.position = transform.position;
    }
}
